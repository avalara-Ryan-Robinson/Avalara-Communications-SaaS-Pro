/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    Handler for input file processing.

 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Avalara.TestCommon.APIObjects;
using static Avalara.TestCommon.Common.EnumeratedTypes;

namespace Avalara.TestCommon.DataSetup
{
   public class InputHandler
   {
      private const int MIN_VIABLE_COLUMNS = 1;
      internal List<InputStructs.TelecomColumnMapping> Mappings;
      private const string DEFAULT_VALUE_FNAME = "Default.*";
      public string WorkingDirectory = string.Empty;
      private FileVersionInfo VersionInfo = null;
      const bool EnableLogging = true;
      List<Transaction> transactionList = null;
      InputStructs.SaaSBasicTelecomTrans saasTrans = null;

      public InputHandler()
      {
         Mappings = SetDefaultSaaSTelecomColumnMappings();
         transactionList = new List<Transaction>();
         saasTrans = new InputStructs.SaaSBasicTelecomTrans();
      }

      public int GetTransactionCount()
      {
         return (transactionList == null) ? 0 : transactionList.Count;
      }

      public List<Transaction> GetTransactionList()
      {
         return transactionList;
      }

      public void InitializeManager(string inputfname, FileVersionInfo fvi)
      {
         VersionInfo = fvi;

         FileInfo fi = new FileInfo(inputfname);
         WorkingDirectory = fi.DirectoryName;

         string extension = inputfname.Substring(inputfname.LastIndexOf('.'));
         string stafile = inputfname.Replace(extension, "sta");
         string errptfile = inputfname.Replace(extension, "err");

      }

      public void Close()
      {
      }

      private string[] ProcessLineWithQuotes(string text)
      {
         Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);

         List<string> ls = new List<string>();
         foreach (Match match in csvSplit.Matches(text))
         {
            ls.Add(match.Value.TrimStart(','));
         }

         return ls.ToArray();
      }

      private InputStructs.SaaSBasicTelecomTrans PreProcessBatchLine(String text, List<InputStructs.ClientColumnMapping> cmap,
         InputStructs.SaaSBasicTelecomTrans def, int line)
      {
         //Exceptions should be passed upwards for error reporting
         int column_index = 0;
         if (string.IsNullOrEmpty(text)) return null;

         string[] fields = ProcessLineWithQuotes(text);
         if (fields.Length < MIN_VIABLE_COLUMNS)
         {
            throw new Exception(String.Format("Input line {0} invalid: [{1}]", line, text));
         }

         saasTrans.SetDefaults();

         try
         {
            for (column_index = 0; column_index < fields.Length; column_index++)
            {
               String field = fields[column_index].TrimEnd();
               if (field.Length == 0)
               {
                  continue; //Allow default to be used
               }

               // Get rid of leading space(s) - lines with all spaces already removed by TrimEnd()
               field = field.TrimStart();

               InputStructs.ClientColumnMapping item = cmap.Find(x => x.Idx.Equals(column_index));
               if (item == null)
               {
                  throw new Exception(string.Format("Index Error: column [{0}] is not valid", column_index));
               }

               saasTrans.SetField(item.SaaSDataType, field);
            }
         }
         catch (Exception ex)
         {
            String exMsg = String.Format("Caught exception processing {1}:{2} [index {2}]",
               text, fields[column_index], column_index);
            throw new Exception(exMsg + ex.Message);
         }

         return saasTrans;
      } // end PreProcessBatchLine()

      private InputStructs.SaaSBasicTelecomTrans ProcessBatchLine(String text, List<InputStructs.ClientColumnMapping> cmap,
         InputStructs.SaaSBasicTelecomTrans def, int line, ref InputStructs.RequestTypes reqType,
         out Transaction ttr, List<InputStructs.ClientColumnMapping> keyCols = null)
      {
         List<string> warningMsgs = new List<string>();
         ttr = null;

         //Exceptions should be passed upwards for error reporting
         if (string.IsNullOrEmpty(text)) return null;

         InputStructs.SaaSBasicTelecomTrans sbtt = PreProcessBatchLine(text, cmap, def, line);

         string warnMsg = string.Empty;
         ttr = new Transaction();

         sbtt.ConvertTransaction(ref ttr, false, ref warningMsgs);

         //if (warningMsgs.Count > 0) RptMgr.OutputWarnings(warningMsgs);

         //ValidateResults(ref ttr, ref suttr, sbtt, ref sbtt.RequestTypeEnum);

         //Set reference to request type 
         ValidateJurisdiction(ref ttr);
         reqType = sbtt.RequestTypeEnum;

         return sbtt;
      } // end ProcessBatchLine()

      public List<Transaction> ProcessInputTransactions(FileInfo fi,
         out int convLines, out int processedLines, out int failedLines)
      {
         transactionList.Clear();
         WorkingDirectory = fi.DirectoryName;

         //RptMgr.Rpts.StaHdl.WriteLine(String.Format("Pre-Processing input file [{0}]\n", inputFilename));
         bool columnsMappedFlag = false;
         List<InputStructs.ClientColumnMapping> clientMappings = null;
         List<InputStructs.ClientColumnMapping> clientKeyMappings = null;
         InputStructs.SaaSBasicTelecomTrans defTelTrans = null;
         int line = 0;
         string defaultFname = string.Empty;
         convLines = 0;
         failedLines = 0;
         processedLines = 0;

         try
         {
            if (!fi.Exists)
            {
               throw new Exception(String.Format("Input file [{0}] not found!  Verify file exists and try again.\n",
                  fi.FullName));
            }

            #region ProcessingInputFile

            using (TextReader tr = new StreamReader(fi.FullName))
            {
               String lineOfText = null;
               InputStructs.SaaSBasicTelecomTrans sbtt = null;
               while ((lineOfText = tr.ReadLine()) != null)
               {
                  line++;
                  if (!columnsMappedFlag)
                  {
                     try
                     {
                        clientMappings = MapColumns(lineOfText);
                     }
                     catch (Exception)
                     {
                        throw new Exception("Mapping failed");
                     }

                     columnsMappedFlag = true;
                     continue;
                  }

                  if ((string.IsNullOrEmpty(lineOfText)) || (lineOfText[0] == ','))
                  {
                     failedLines++;
                     continue;  //Do not pass empty lines on or an exeption will get generated
                  }

                  InputStructs.RequestTypes reqType = InputStructs.RequestTypes.End;
                  Transaction trans = null;
                  try
                  {
                     sbtt = ProcessBatchLine(lineOfText, clientMappings, defTelTrans,
                        line, ref reqType, out trans, clientKeyMappings);
                     if (trans != null)
                     {
                        transactionList.Add(trans);
                        convLines++;
                     }
                     else
                     {
                        failedLines++;
                        continue;
                     }
                  }
                  catch (Exception)
                  {
                     failedLines++;
                     continue;
                  }

               } // end while loop

               tr.Close();
               tr.Dispose();
            }

            #endregion
         }
         catch (Exception e)
         {
            System.Diagnostics.Debug.WriteLine(e.Message);
            throw;
         }

         return transactionList;
      } // end ProcessInputTransactions()


      public List<InputStructs.TelecomColumnMapping> SetDefaultSaaSTelecomColumnMappings()
      {
         // Values should have no spaces (spaces will be removed from client headers)
         Mappings = new List<InputStructs.TelecomColumnMapping>();
         Mappings.Add(new InputStructs.TelecomColumnMapping("RequestType", InputStructs.SaaSBasicTelecomTransFields.RequestType));

         //BillTo Jurisdiction Fields
         Mappings.Add(new InputStructs.TelecomColumnMapping("BillToPCode", InputStructs.SaaSBasicTelecomTransFields.BillToPCode));
         Mappings.Add(new InputStructs.TelecomColumnMapping("BillToCountry", InputStructs.SaaSBasicTelecomTransFields.BillToCountryISO));
         Mappings.Add(new InputStructs.TelecomColumnMapping("BillToState", InputStructs.SaaSBasicTelecomTransFields.BillToState));
         Mappings.Add(new InputStructs.TelecomColumnMapping("BillToCounty", InputStructs.SaaSBasicTelecomTransFields.BillToCounty));
         Mappings.Add(new InputStructs.TelecomColumnMapping("BillToLocality", InputStructs.SaaSBasicTelecomTransFields.BillToLocality));
         Mappings.Add(new InputStructs.TelecomColumnMapping("BillToZipCode", InputStructs.SaaSBasicTelecomTransFields.BillToZipCode));
         Mappings.Add(new InputStructs.TelecomColumnMapping("BillToZipP4", InputStructs.SaaSBasicTelecomTransFields.BillToZipP4));
         Mappings.Add(new InputStructs.TelecomColumnMapping("BillToFipsCode", InputStructs.SaaSBasicTelecomTransFields.BillToFipsCode));
         Mappings.Add(new InputStructs.TelecomColumnMapping("BillToNpaNxx", InputStructs.SaaSBasicTelecomTransFields.BillToNpaNxx));

         //Origination Jurisdiction Fields
         Mappings.Add(new InputStructs.TelecomColumnMapping("OriginationPCode", InputStructs.SaaSBasicTelecomTransFields.OriginationPCode));
         Mappings.Add(new InputStructs.TelecomColumnMapping("OriginationCountry", InputStructs.SaaSBasicTelecomTransFields.OriginationCountryISO));
         Mappings.Add(new InputStructs.TelecomColumnMapping("OriginationState", InputStructs.SaaSBasicTelecomTransFields.OriginationState));
         Mappings.Add(new InputStructs.TelecomColumnMapping("OriginationCounty", InputStructs.SaaSBasicTelecomTransFields.OriginationCounty));
         Mappings.Add(new InputStructs.TelecomColumnMapping("OriginationLocality", InputStructs.SaaSBasicTelecomTransFields.OriginationLocality));
         Mappings.Add(new InputStructs.TelecomColumnMapping("OriginationZipCode", InputStructs.SaaSBasicTelecomTransFields.OriginationZipCode));
         Mappings.Add(new InputStructs.TelecomColumnMapping("OriginationZipP4", InputStructs.SaaSBasicTelecomTransFields.OriginationZipP4));
         Mappings.Add(new InputStructs.TelecomColumnMapping("OriginationFipsCode", InputStructs.SaaSBasicTelecomTransFields.OriginationFipsCode));
         Mappings.Add(new InputStructs.TelecomColumnMapping("OriginationNpaNxx", InputStructs.SaaSBasicTelecomTransFields.OriginationNpaNxx));

         //Termination Jurisdiction Fields
         Mappings.Add(new InputStructs.TelecomColumnMapping("TerminationPCode", InputStructs.SaaSBasicTelecomTransFields.TerminationPCode));
         Mappings.Add(new InputStructs.TelecomColumnMapping("TerminationCountry", InputStructs.SaaSBasicTelecomTransFields.TerminationCountryISO));
         Mappings.Add(new InputStructs.TelecomColumnMapping("TerminationState", InputStructs.SaaSBasicTelecomTransFields.TerminationState));
         Mappings.Add(new InputStructs.TelecomColumnMapping("TerminationCounty", InputStructs.SaaSBasicTelecomTransFields.TerminationCounty));
         Mappings.Add(new InputStructs.TelecomColumnMapping("TerminationLocality", InputStructs.SaaSBasicTelecomTransFields.TerminationLocality));
         Mappings.Add(new InputStructs.TelecomColumnMapping("TerminationZipCode", InputStructs.SaaSBasicTelecomTransFields.TerminationZipCode));
         Mappings.Add(new InputStructs.TelecomColumnMapping("TerminationZipP4", InputStructs.SaaSBasicTelecomTransFields.TerminationZipP4));
         Mappings.Add(new InputStructs.TelecomColumnMapping("TerminationFipsCode", InputStructs.SaaSBasicTelecomTransFields.TerminationFipsCode));
         Mappings.Add(new InputStructs.TelecomColumnMapping("TerminationNpaNxx", InputStructs.SaaSBasicTelecomTransFields.TerminationNpaNxx));

         //Base Calculation Fields
         Mappings.Add(new InputStructs.TelecomColumnMapping("TransactionType", InputStructs.SaaSBasicTelecomTransFields.TransactionType));
         Mappings.Add(new InputStructs.TelecomColumnMapping("ServiceType", InputStructs.SaaSBasicTelecomTransFields.ServiceType));
         Mappings.Add(new InputStructs.TelecomColumnMapping("Charge", InputStructs.SaaSBasicTelecomTransFields.Charge));
         Mappings.Add(new InputStructs.TelecomColumnMapping("Date", InputStructs.SaaSBasicTelecomTransFields.Date));
         Mappings.Add(new InputStructs.TelecomColumnMapping("InvoiceDate", InputStructs.SaaSBasicTelecomTransFields.Date));

         //Extended (Defaultable) Calculation Fields
         Mappings.Add(new InputStructs.TelecomColumnMapping("Lines", InputStructs.SaaSBasicTelecomTransFields.Lines));
         Mappings.Add(new InputStructs.TelecomColumnMapping("Minutes", InputStructs.SaaSBasicTelecomTransFields.Minutes));
         Mappings.Add(new InputStructs.TelecomColumnMapping("BusinessClass", InputStructs.SaaSBasicTelecomTransFields.BusinessClass));
         Mappings.Add(new InputStructs.TelecomColumnMapping("CustomerType", InputStructs.SaaSBasicTelecomTransFields.CustomerType));
         Mappings.Add(new InputStructs.TelecomColumnMapping("Facilities", InputStructs.SaaSBasicTelecomTransFields.FacilitiesBased));
         Mappings.Add(new InputStructs.TelecomColumnMapping("Franchise", InputStructs.SaaSBasicTelecomTransFields.Franchise));
         Mappings.Add(new InputStructs.TelecomColumnMapping("Incorporated", InputStructs.SaaSBasicTelecomTransFields.Incorporated));
         Mappings.Add(new InputStructs.TelecomColumnMapping("Lifeline", InputStructs.SaaSBasicTelecomTransFields.Lifeline));
         Mappings.Add(new InputStructs.TelecomColumnMapping("Regulated", InputStructs.SaaSBasicTelecomTransFields.Regulated));
         Mappings.Add(new InputStructs.TelecomColumnMapping("Sale", InputStructs.SaaSBasicTelecomTransFields.Sale));
         Mappings.Add(new InputStructs.TelecomColumnMapping("ServiceClass", InputStructs.SaaSBasicTelecomTransFields.ServiceClass));

         // Reporting Fields
         Mappings.Add(new InputStructs.TelecomColumnMapping("CompanyIdentifier", InputStructs.SaaSBasicTelecomTransFields.CompanyIdentifier));
         Mappings.Add(new InputStructs.TelecomColumnMapping("CustomerNumber", InputStructs.SaaSBasicTelecomTransFields.CustomerNumber));
         Mappings.Add(new InputStructs.TelecomColumnMapping("InvoiceNumber", InputStructs.SaaSBasicTelecomTransFields.InvoiceNumber));

         // Zip Lookup Specific Fields
         Mappings.Add(new InputStructs.TelecomColumnMapping("Country", InputStructs.SaaSBasicTelecomTransFields.BillToCountryISO));
         Mappings.Add(new InputStructs.TelecomColumnMapping("State", InputStructs.SaaSBasicTelecomTransFields.BillToState));
         Mappings.Add(new InputStructs.TelecomColumnMapping("County", InputStructs.SaaSBasicTelecomTransFields.BillToCounty));
         Mappings.Add(new InputStructs.TelecomColumnMapping("Locality", InputStructs.SaaSBasicTelecomTransFields.BillToLocality));
         Mappings.Add(new InputStructs.TelecomColumnMapping("ZipCode", InputStructs.SaaSBasicTelecomTransFields.BillToZipCode));
         Mappings.Add(new InputStructs.TelecomColumnMapping("ZipP4", InputStructs.SaaSBasicTelecomTransFields.BillToZipP4));
         Mappings.Add(new InputStructs.TelecomColumnMapping("BestMatch", InputStructs.SaaSBasicTelecomTransFields.BestMatch));
         Mappings.Add(new InputStructs.TelecomColumnMapping("LimitResults", InputStructs.SaaSBasicTelecomTransFields.LimitResults));
         Mappings.Add(new InputStructs.TelecomColumnMapping("JurisdictionDetails", InputStructs.SaaSBasicTelecomTransFields.JurisdictionDetails));

         return Mappings;
      } // end SetDefaultSaaSTelecomColumnMappings

      public List<InputStructs.ClientColumnMapping> MapColumns(string header)
      {
         int column_index = 0;
         int mapped = 0;
         if (string.IsNullOrEmpty(header)) return null;

         List<InputStructs.ClientColumnMapping> list = new List<InputStructs.ClientColumnMapping>();

         string[] fields = ProcessLineWithQuotes(header);
         if (fields.Length > 0)
         {
            //RptMgr.Rpts.StaHdl.WriteLine("Mapping {0} columns", fields.Length);
            try
            {
               for (column_index = 0; column_index < fields.Length; column_index++)
               {
                  InputStructs.ClientColumnMapping ccmap = null;
                  string value = fields[column_index].Replace(" ", ""); //Strip out spaces

                  InputStructs.TelecomColumnMapping item = Mappings.Find(
                     x => x.Header.ToUpper() == value.ToUpper());

                  if (item == null)
                  {
                     item = Mappings.Find(
                        x => value.ToUpper().StartsWith(x.Header.ToUpper()));
                  }

                  if (item == null)
                  {
                     ccmap = new InputStructs.ClientColumnMapping(column_index, InputStructs.SaaSBasicTelecomTransFields.End,
                        fields[column_index]);
                     //RptMgr.Rpts.StaHdl.WriteLine("Warning: column {0}:[{1}] is unmapped", column_index, fields[column_index]);
                  }
                  else
                  {
                     ccmap = new InputStructs.ClientColumnMapping(column_index, item.SaaSDataType, fields[column_index]);
                     mapped++;
                  }

                  if ((list.Count > 0) && (item != null))
                  {
                     if (list.Find(
                        x => x.SaaSDataType == item.SaaSDataType) != null)
                     {
                        throw new Exception("Error: column is already mapped!");
                     }
                  }
                  list.Add(ccmap);
                  //RptMgr.Rpts.StaHdl.WriteLine(ccmap.ToString());
               }
               //RptMgr.Rpts.StaHdl.WriteLine("Column mapping complete - mapped {0} / unmapped {1}", mapped, column_index - mapped);
               //RptMgr.Rpts.StaHdl.WriteLine("");
            }
            catch (Exception ex)
            {
               String exMsg = String.Format("MapColumns(\"{0}\")\n" +
                                            "Caught exception processing {1} [index {2}]\n",
                  header, fields[column_index], column_index);
               throw new Exception(exMsg + ex.Message);
            }
         }
         return list;
      } // end MapColumns

      /// <summary>
      /// Method for validating jurisdictions.  
      /// Called by the higher level method for validating a transaction
      /// </summary>
      /// <param name="t : Transaction with jurisdictions"></param>
      /// <param name="sbtt : SaaSBasicTelecomTrans with input files"></param>
      public void ValidateJurisdiction(ref Transaction t)
      {
         JType billtoJType = JType.None;
         JType origJType = JType.None;
         JType termJType = JType.None;

         if (t.BillToPCode.HasValue) billtoJType = JType.PCode;
         else if ((t.BillToAddress != null) && (!string.IsNullOrWhiteSpace(t.BillToAddress.CountryISO))) billtoJType = JType.ZipAddress;
         else if (!string.IsNullOrWhiteSpace(t.BillToFipsCode)) billtoJType = JType.FipsCode;
         else if (t.BillToNpaNxx.HasValue) billtoJType = JType.NpaNxx;

         if (t.OriginationPCode.HasValue) origJType = JType.PCode;
         else if ((t.OriginationAddress != null) && (!string.IsNullOrWhiteSpace(t.OriginationAddress.CountryISO))) origJType = JType.ZipAddress;
         else if (!string.IsNullOrWhiteSpace(t.OriginationFipsCode)) origJType = JType.FipsCode;
         else if (t.OriginationNpaNxx.HasValue) origJType = JType.NpaNxx;

         if (t.TerminationPCode.HasValue) termJType = JType.PCode;
         else if ((t.TerminationAddress != null) && (!string.IsNullOrWhiteSpace(t.TerminationAddress.CountryISO))) termJType = JType.ZipAddress;
         else if (!string.IsNullOrWhiteSpace(t.TerminationFipsCode)) termJType = JType.FipsCode;
         else if (t.TerminationNpaNxx.HasValue) termJType = JType.NpaNxx;

         // Pre-Processing Check: Fail if no jurisdictions were provided
         if ((billtoJType == JType.None) &&
             (origJType == JType.None) &&
             (termJType == JType.None))
         {
            throw new Exception("ValidateJurisdiction: No jurisdiction data set - must have at least one valid jurisdiction");
         }

         if ((billtoJType != JType.None) &&
             (origJType != JType.None) &&
             (termJType != JType.None))
         {
            //Finished - no need to continue
            return;
         }

         if (billtoJType != JType.None)
         {
            if (billtoJType == JType.PCode)
            {
               if (origJType == JType.None) { t.OriginationPCode = t.BillToPCode; origJType = JType.PCode; }
               if (termJType == JType.None) { t.TerminationPCode = t.BillToPCode; termJType = JType.PCode; }
            }
            else if (billtoJType == JType.ZipAddress)
            {
               if (origJType == JType.None) { t.OriginationAddress = t.BillToAddress; origJType = JType.ZipAddress; }
               if (termJType == JType.None) { t.TerminationAddress = t.BillToAddress; termJType = JType.ZipAddress; }
            }
            else if (billtoJType == JType.FipsCode)
            {
               if (origJType == JType.None) { t.OriginationFipsCode = t.BillToFipsCode; origJType = JType.FipsCode; }
               if (termJType == JType.None) { t.TerminationFipsCode = t.BillToFipsCode; termJType = JType.FipsCode; }
            }
            else if (billtoJType == JType.NpaNxx)
            {
               if (origJType == JType.None) { t.OriginationNpaNxx = t.BillToNpaNxx; origJType = JType.NpaNxx; }
               if (termJType == JType.None) { t.TerminationNpaNxx = t.BillToNpaNxx; termJType = JType.NpaNxx; }
            }
         }
         else if (origJType != JType.None)
         {
            if (origJType == JType.PCode)
            {
               if (billtoJType == JType.None) { t.BillToPCode = t.OriginationPCode; billtoJType = JType.PCode; }
               if (termJType == JType.None) { t.TerminationPCode = t.OriginationPCode; termJType = JType.PCode; }
            }
            else if (origJType == JType.ZipAddress)
            {
               if (billtoJType == JType.None) { t.BillToAddress = t.OriginationAddress; billtoJType = JType.ZipAddress; }
               if (termJType == JType.None) { t.TerminationAddress = t.OriginationAddress; termJType = JType.ZipAddress; }
            }
            else if (origJType == JType.FipsCode)
            {
               if (billtoJType == JType.None) { t.BillToFipsCode = t.OriginationFipsCode; billtoJType = JType.FipsCode; }
               if (termJType == JType.None) { t.TerminationFipsCode = t.OriginationFipsCode; termJType = JType.FipsCode; }
            }
            else if (origJType == JType.NpaNxx)
            {
               if (billtoJType == JType.None) { t.BillToNpaNxx = t.OriginationNpaNxx; billtoJType = JType.NpaNxx; }
               if (termJType == JType.None) { t.TerminationNpaNxx = t.OriginationNpaNxx; termJType = JType.NpaNxx; }
            }
         }
         else if (termJType != JType.None)
         {
            if (termJType == JType.PCode)
            {
               if (billtoJType == JType.None) { t.BillToPCode = t.TerminationPCode; billtoJType = JType.PCode; }
               if (origJType == JType.None) { t.OriginationPCode = t.TerminationPCode; origJType = JType.PCode; }
            }
            else if (termJType == JType.ZipAddress)
            {
               if (billtoJType == JType.None) { t.BillToAddress = t.TerminationAddress; billtoJType = JType.ZipAddress; }
               if (origJType == JType.None) { t.OriginationAddress = t.TerminationAddress; origJType = JType.ZipAddress; }
            }
            else if (termJType == JType.FipsCode)
            {
               if (billtoJType == JType.None) { t.BillToFipsCode = t.TerminationFipsCode; billtoJType = JType.FipsCode; }
               if (origJType == JType.None) { t.OriginationFipsCode = t.TerminationFipsCode; origJType = JType.FipsCode; }
            }
            else if (termJType == JType.NpaNxx)
            {
               if (billtoJType == JType.None) { t.BillToNpaNxx = t.TerminationNpaNxx; billtoJType = JType.NpaNxx; }
               if (origJType == JType.None) { t.OriginationNpaNxx = t.TerminationNpaNxx; origJType = JType.NpaNxx; }
            }
         }

         if ((billtoJType != JType.None) &&
             (origJType != JType.None) &&
             (termJType != JType.None))
         {
            //Finished - no need to continue
            return;
         }

         //This is a safety check as the process should never hit this line
         // If this line is reached then there is a logic error above
         throw new Exception("ValidateJurisdiction: Failure to validate all jurisdictions");

      } // end ValidateJurisdiction

   } // end class InputHandler
} // end namespace

