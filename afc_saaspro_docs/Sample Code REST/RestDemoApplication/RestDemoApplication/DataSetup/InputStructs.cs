/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    Data Structs related to Rest Demo Application processing


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System;
using System.Collections.Generic;
using Avalara.TestCommon.APIObjects;

namespace Avalara.TestCommon.DataSetup
{
   public class InputStructs
   {
      // Defaults from SaaS Standard Manual
      public const RequestTypes DefReqTypeEnum = RequestTypes.CalcTaxes;
      public const string DefRequestType = "CalcTaxes";
      public const string DefCustomerType = "Business";
      public const string DefSale = "Sale";
      public const string DefIncorporated = "True";
      public const string DefRegulated = "False";
      public const string DefServiceClass = "Local";
      public const string DefLifeline = "False";
      public const string DefFacilitiesBased = "True";
      public const string DefFranchise = "True";
      public const string DefBusinessClass = "CLEC";

      public const int FipsCodeLength = 10;
      public const int UsaZipCodeLength = 5;
      public const int CanadaZipCodeLength = 6;

      public const int BUNDLE_ID_START = 20000;

      public InputStructs()
      {
      }

      public static bool CheckBoolTrue(char c)
      {
         return ((c == 'T') || (c == '1') || (c == 'Y'));
      }

      public static bool CheckBoolFalse(char c)
      {
         return ((c == 'F') || (c == '0') || (c == 'N'));
      }

      public static bool CheckBoolValid(char c)
      {
         return (CheckBoolTrue(c) || CheckBoolFalse(c));
      }


      public enum JurisdictionTypes
      {
         PCode,
         Address,
         Fips,
         Npanxx,
         Invalid
      }

      public enum RequestTypes
      {
         CalcTaxes,
         CalcAdj,
         CalcRev,
         CalcRevAdj,
         ZipLookup,
         End
      }

      public class ClientColumnMapping
      {
         public int Idx;
         public SaaSBasicTelecomTransFields SaaSDataType;
         public string Value;

         public ClientColumnMapping(int i, SaaSBasicTelecomTransFields t, string v)
         {
            Idx = i;
            SaaSDataType = t;
            Value = v;
         }

         public override string ToString()
         {
            string val = string.Empty;
            if ((SaaSDataType > SaaSBasicTelecomTransFields.Begin) &&
                (SaaSDataType < SaaSBasicTelecomTransFields.End))
            {
               val = string.Format("  Mapped {0}:{1}", Idx, Value);
            }
            else
            {
               val = string.Format("  Unmapped {0}:{1}", Idx, Value);
            }
            return val;
         }

      }

      public class TelecomColumnMapping
      {
         public string Header;
         public SaaSBasicTelecomTransFields SaaSDataType;

         public TelecomColumnMapping(string h, SaaSBasicTelecomTransFields t)
         {
            Header = h;
            SaaSDataType = t;
         }
      }

      // Maps to SaaSBasicTelecomTrans
      public enum SaaSBasicTelecomTransFields
      {
         Begin,
         RequestType,

         //BillTo Jurisdiction Fields
         BillToPCode,
         BillToCountryISO,
         BillToState,
         BillToCounty,
         BillToLocality,
         BillToZipCode,
         BillToZipP4,
         BillToFipsCode,
         BillToNpaNxx,

         //Origination Jurisdiction Fields
         OriginationPCode,
         OriginationCountryISO,
         OriginationState,
         OriginationCounty,
         OriginationLocality,
         OriginationZipCode,
         OriginationZipP4,
         OriginationFipsCode,
         OriginationNpaNxx,

         //Termination Jurisdiction Fields
         TerminationPCode,
         TerminationCountryISO,
         TerminationState,
         TerminationCounty,
         TerminationLocality,
         TerminationZipCode,
         TerminationZipP4,
         TerminationFipsCode,
         TerminationNpaNxx,

         //Base Calculation Fields
         TransactionType,
         ServiceType,
         Charge,
         Date,

         //Extended (Defaultable) Calculation Fields
         Lines,
         Minutes,
         BusinessClass,
         CustomerType,
         FacilitiesBased,
         Franchise,
         Incorporated,
         Lifeline,
         Regulated,
         Sale,
         ServiceClass,

         // Reporting Fields
         CompanyIdentifier,
         CustomerNumber,
         InvoiceNumber,

         // Zip Lookup Specific Fields
         BestMatch,
         LimitResults,
         JurisdictionDetails,

         End
      }

      public class SaaSBasicTelecomTrans
      {
         public RequestTypes RequestTypeEnum;
         public string RequestType;

         //BillTo Jurisdiction Fields
         public string BillToPCode;
         public string BillToCountryISO;
         public string BillToState;
         public string BillToCounty;
         public string BillToLocality;
         public string BillToZipCode;
         public string BillToZipP4;
         public string BillToFipsCode;
         public string BillToNpaNxx;

         //Origination Jurisdiction Fields
         public string OriginationPCode;
         public string OriginationCountryISO;
         public string OriginationState;
         public string OriginationCounty;
         public string OriginationLocality;
         public string OriginationZipCode;
         public string OriginationZipP4;
         public string OriginationFipsCode;
         public string OriginationNpaNxx;

         //Termination Jurisdiction Fields
         public string TerminationPCode;
         public string TerminationCountryISO;
         public string TerminationState;
         public string TerminationCounty;
         public string TerminationLocality;
         public string TerminationZipCode;
         public string TerminationZipP4;
         public string TerminationFipsCode;
         public string TerminationNpaNxx;

         //Base Calculation Fields
         public string TransactionType;
         public string ServiceType;
         public string Charge;
         public string Date;

         //Extended (Defaultable) Calculation Fields
         public string Lines;
         public string Minutes;
         public string BusinessClass;
         public string CustomerType;
         public string FacilitiesBased;
         public string Franchise;
         public string Incorporated;
         public string Lifeline;
         public string Regulated;
         public string Sale;
         public string ServiceClass;

         // Reporting Fields
         public string CompanyIdentifier;
         public string CustomerNumber;
         public string InvoiceNumber;

         // Zip Lookup Specific Fields
         public string BestMatch;
         public string LimitResults;
         public string JurisdictionDetails;

         public SaaSBasicTelecomTrans()
         {
            SetDefaults();
         }

         public void SetDefaults()
         { 
            RequestTypeEnum = DefReqTypeEnum;
            RequestType = DefRequestType;

            //BillTo Jurisdiction Fields
            BillToPCode = string.Empty;
            BillToCountryISO = string.Empty;
            BillToState = string.Empty;
            BillToCounty = string.Empty;
            BillToLocality = string.Empty;
            BillToZipCode = string.Empty;
            BillToZipP4 = string.Empty;
            BillToFipsCode = string.Empty;
            BillToNpaNxx = string.Empty;

            //Origination Jurisdiction Fields
            OriginationPCode = string.Empty;
            OriginationCountryISO = string.Empty;
            OriginationState = string.Empty;
            OriginationCounty = string.Empty;
            OriginationLocality = string.Empty;
            OriginationZipCode = string.Empty;
            OriginationZipP4 = string.Empty;
            OriginationFipsCode = string.Empty;
            OriginationNpaNxx = string.Empty;

            //Termination Jurisdiction Fields
            TerminationPCode = string.Empty;
            TerminationCountryISO = string.Empty;
            TerminationState = string.Empty;
            TerminationCounty = string.Empty;
            TerminationLocality = string.Empty;
            TerminationZipCode = string.Empty;
            TerminationZipP4 = string.Empty;
            TerminationFipsCode = string.Empty;
            TerminationNpaNxx = string.Empty;

            //Base Calculation Fields
            TransactionType = string.Empty;
            ServiceType = string.Empty;
            Charge = string.Empty;
            Date = string.Empty;

            //Extended (Defaultable) Calculation Fields
            Lines = string.Empty;
            Minutes = string.Empty;
            BusinessClass = DefBusinessClass;
            CustomerType = DefCustomerType;
            FacilitiesBased = DefFacilitiesBased;
            Franchise = DefFranchise;
            Incorporated = DefIncorporated;
            Lifeline = DefLifeline;
            Regulated = DefRegulated;
            Sale = DefSale;
            ServiceClass = DefServiceClass;

            // Reporting Fields
            CompanyIdentifier = string.Empty;
            CustomerNumber = string.Empty;
            InvoiceNumber = string.Empty;

            // Zip Lookup Specific Fields
            BestMatch = string.Empty;
            LimitResults = string.Empty;
            JurisdictionDetails = string.Empty;

         }

         public SaaSBasicTelecomTrans(SaaSBasicTelecomTrans def)
         {
            RequestTypeEnum = def.RequestTypeEnum;
            RequestType = def.RequestType;

            //BillTo Jurisdiction Fields
            BillToPCode = def.BillToPCode;
            BillToCountryISO = def.BillToCountryISO;
            BillToState = def.BillToState;
            BillToCounty = def.BillToCounty;
            BillToLocality = def.BillToLocality;
            BillToZipCode = def.BillToZipCode;
            BillToZipP4 = def.BillToZipP4;
            BillToFipsCode = def.BillToFipsCode;
            BillToNpaNxx = def.BillToNpaNxx;

            //Origination Jurisdiction Fields
            OriginationPCode = def.OriginationPCode;
            OriginationCountryISO = def.OriginationCountryISO;
            OriginationState = def.OriginationState;
            OriginationCounty = def.OriginationCounty;
            OriginationLocality = def.OriginationLocality;
            OriginationZipCode = def.OriginationZipCode;
            OriginationZipP4 = def.OriginationZipP4;
            OriginationFipsCode = def.OriginationFipsCode;
            OriginationNpaNxx = def.OriginationNpaNxx;

            //Termination Jurisdiction Fields
            TerminationPCode = def.TerminationPCode;
            TerminationCountryISO = def.TerminationCountryISO;
            TerminationState = def.TerminationState;
            TerminationCounty = def.TerminationCounty;
            TerminationLocality = def.TerminationLocality;
            TerminationZipCode = def.TerminationZipCode;
            TerminationZipP4 = def.TerminationZipP4;
            TerminationFipsCode = def.TerminationFipsCode;
            TerminationNpaNxx = def.TerminationNpaNxx;

            //Base Calculation Fields
            TransactionType = def.TransactionType;
            ServiceType = def.ServiceType;
            Charge = def.Charge;
            Date = def.Date;

            //Extended (Defaultable) Calculation Fields
            Lines = def.Lines;
            Minutes = def.Minutes;
            BusinessClass = def.BusinessClass;
            CustomerType = def.CustomerType;
            FacilitiesBased = def.FacilitiesBased;
            Franchise = def.Franchise;
            Incorporated = def.Incorporated;
            Lifeline = def.Lifeline;
            Regulated = def.Regulated;
            Sale = def.Sale;
            ServiceClass = def.ServiceClass;

            // Reporting Fields
            CompanyIdentifier = def.CompanyIdentifier;
            CustomerNumber = def.CustomerNumber;
            InvoiceNumber = def.InvoiceNumber;

            // Zip Lookup Specific Fields
            BestMatch = def.BestMatch;
            LimitResults = def.LimitResults;
            JurisdictionDetails = def.JurisdictionDetails;

         }

         public bool IsTelecom(out RequestTypes rt, ref string wMsg)
         {
            bool rv = false;
            rt = GetRequestType(ref wMsg);
            switch (rt)
            {
               case RequestTypes.CalcTaxes:
               case RequestTypes.CalcAdj:
               case RequestTypes.CalcRev:
               case RequestTypes.CalcRevAdj:
                  rv = true;
                  break;
               case RequestTypes.ZipLookup:
                  rv = false;
                  break;
            }

            return (rv);
         }

         public bool IsTelecom()
         {
            bool rv = false;
            switch (RequestTypeEnum)
            {
               case RequestTypes.CalcTaxes:
               case RequestTypes.CalcAdj:
               case RequestTypes.CalcRev:
               case RequestTypes.CalcRevAdj:
                  rv = true;
                  break;
               case RequestTypes.ZipLookup:
                  rv = false;
                  break;
            }

            return (rv);
         }

         public static bool TestAndSetAddress(
            ref string ctryIso, ref string state, ref string county, ref string city,
            ref string zip, ref string zipP4, out ZipAddress address)
         {
            address = null;

            if (string.IsNullOrEmpty(ctryIso) && string.IsNullOrEmpty(state) &&
               string.IsNullOrEmpty(county) && string.IsNullOrEmpty(city) &&
               string.IsNullOrEmpty(zip))
            {
               return false;
            }

            if ((zip != null) && (zip.Length > 2) &&
               (zip.Length < InputStructs.UsaZipCodeLength) && (ctryIso.Equals("USA")))
            {
               zip = zip.PadLeft(InputStructs.UsaZipCodeLength, '0');
            }

            address = new ZipAddress(
               ctryIso,
               state,
               county,
               city,
               zip,
               zipP4);

            //Fix needed until Canada zip codes natively supported
            if ((ctryIso == "CAN") && (zip != null) && (zip.Length > InputStructs.UsaZipCodeLength))
            {
               if (zip.Length > InputStructs.CanadaZipCodeLength)
               {
                  zip = zip.Replace("-", "");
                  zip = zip.Replace(" ", "");
               }
               address.ZipCode = zip.Substring(0, 3);
               address.ZipP4 = zip.Substring(3, 3);
            }

            return (address != null);
         }

         public void ConvertTransaction(ref Transaction t, bool defaults, ref List<string> warningMsgs)
         {
            short sbuff;
            int ibuff;
            uint uibuff;
            double dbuff;
            ZipAddress addrBuff = null;
            string warnMsg = string.Empty;
            bool isTelecomReq = IsTelecom(out RequestTypeEnum, ref warnMsg);

            if (!string.IsNullOrEmpty(warnMsg))
            {
               warningMsgs.Add(warnMsg);
            }

            //-----------------------------------------------------
            //  Set Non-Default Fields
            //-----------------------------------------------------

            if (!defaults)
            {
               //-----------------------------------------------------
               //  Set Jurisdiction Fields
               //  Note: Order is intentional ... 
               //   PCode -> Address -> FIPs -> NPANXX
               //-----------------------------------------------------

               // BillTo
               if (!string.IsNullOrEmpty(BillToPCode))
               {
                  t.BillToPCode = Convert.ToUInt32(BillToPCode);
               }
               else if (TestAndSetAddress(ref BillToCountryISO, ref BillToState,
                  ref BillToCounty, ref BillToLocality, ref BillToZipCode, ref BillToZipP4, out addrBuff))
               {
                  if (addrBuff == null)
                  {
                     throw new Exception(string.Format("ConvertTransaction ERROR: BillTo Address parsing failed!"));
                  }
                  t.BillToAddress = addrBuff;
               }
               else if (!string.IsNullOrEmpty(BillToFipsCode))
               {
                  if ((BillToFipsCode.Length < FipsCodeLength) && (BillToFipsCode.Length > 6))
                  {
                     BillToFipsCode = BillToFipsCode.PadLeft(FipsCodeLength, '0');
                  }
                  t.BillToFipsCode = BillToFipsCode;
               }
               else if (!string.IsNullOrEmpty(BillToNpaNxx))
               {
                  t.BillToNpaNxx = Convert.ToUInt32(BillToNpaNxx);
               }

               // Origination
               if (!string.IsNullOrEmpty(OriginationPCode))
               {
                  t.OriginationPCode = Convert.ToUInt32(OriginationPCode);
               }
               else if (TestAndSetAddress(ref OriginationCountryISO, ref OriginationState,
                  ref OriginationCounty, ref OriginationLocality, ref OriginationZipCode, ref OriginationZipP4, out addrBuff))
               {
                  if (addrBuff == null)
                  {
                     throw new Exception(string.Format("ConvertTransaction ERROR: Origination Address parsing failed!"));
                  }
                  t.OriginationAddress = addrBuff;
               }
               else if (!string.IsNullOrEmpty(OriginationFipsCode))
               {
                  if ((OriginationFipsCode.Length < FipsCodeLength) && (OriginationFipsCode.Length > 6))
                  {
                     OriginationFipsCode = OriginationFipsCode.PadLeft(FipsCodeLength, '0');
                  }
                  t.OriginationFipsCode = OriginationFipsCode;
               }
               else if (!string.IsNullOrEmpty(OriginationNpaNxx))
               {
                  t.OriginationNpaNxx = Convert.ToUInt32(OriginationNpaNxx);
               }

               // Termination
               if (!string.IsNullOrEmpty(TerminationPCode))
               {
                  t.TerminationPCode = Convert.ToUInt32(TerminationPCode);
               }
               else if (TestAndSetAddress(ref TerminationCountryISO, ref TerminationState,
                  ref TerminationCounty, ref TerminationLocality, ref TerminationZipCode, ref TerminationZipP4, out addrBuff))
               {
                  if (addrBuff == null)
                  {
                     throw new Exception(string.Format("ConvertTransaction ERROR: Termination Address parsing failed!"));
                  }
                  t.TerminationAddress = addrBuff;
               }
               else if (!string.IsNullOrEmpty(TerminationFipsCode))
               {
                  if ((TerminationFipsCode.Length < FipsCodeLength) && (TerminationFipsCode.Length > 6))
                  {
                     TerminationFipsCode = TerminationFipsCode.PadLeft(FipsCodeLength, '0');
                  }
                  t.TerminationFipsCode = TerminationFipsCode;
               }
               else if (!string.IsNullOrEmpty(TerminationNpaNxx))
               {
                  t.TerminationNpaNxx = Convert.ToUInt32(TerminationNpaNxx);
               }

               //-----------------------------------------------------
               //  End Set Jurisdiction Fields
               //-----------------------------------------------------

               //-----------------------------------------------------
               //  Set Base Calculation Fields
               //-----------------------------------------------------
               if (!string.IsNullOrEmpty(TransactionType))
               {
                  if (!short.TryParse(TransactionType, out sbuff))
                  {
                     throw new Exception(string.Format("ConvertTransaction: TransactionType [{0}] is not a valid number", TransactionType));
                  }
                  t.TransactionType = sbuff;
               }

               if (!string.IsNullOrEmpty(ServiceType))
               {
                  if (!short.TryParse(ServiceType, out sbuff))
                  {
                     throw new Exception(string.Format("ConvertTransaction: ServiceType [{0}] is not a valid number", ServiceType));
                  }
                  t.ServiceType = sbuff;
               }

               if (!string.IsNullOrEmpty(Charge))
               {
                  if (!double.TryParse(Charge, out dbuff))
                  {
                     throw new Exception(string.Format("ConvertTransaction: Charge [{0}] is not a valid number", Charge));
                  }
                  t.Charge = dbuff;
               }

               if (!string.IsNullOrEmpty(Date))
               {
                  uint u_date = 0;
                  DateTime dt;
                  // If date is numeric, assume YYYYMMDD format - else assume DateTime format
                  if (UInt32.TryParse(Date, out u_date))
                  {
                     int year = (int)(u_date / 10000);
                     int month = (int)((u_date % 10000) / 100);
                     int day = (int)(u_date % 100);
                     try
                     {
                        dt = new DateTime(year, month, day);
                     }
                     catch (Exception)
                     {
                        throw new Exception(string.Format("ConvertTransaction 1: Date [{0}] is not a supported format", Date));
                     }
                  }
                  else if (!DateTime.TryParse(Date, out dt))
                  {
                     throw new Exception(string.Format("ConvertTransaction 2: Date [{0}] is not a supported format", Date));
                  }
                  t.Date = dt;
               }

            } // End non-defaultable fields

            //-----------------------------------------------------
            //  Set Extended (Defaultable) Calculation Fields
            //-----------------------------------------------------
            if (!string.IsNullOrEmpty(Lines))
            {
               if (!int.TryParse(Lines, out ibuff))
               {
                  throw new Exception(string.Format("ConvertTransaction: Lines [{0}] is not a valid number", t.Lines));
               }
               t.Lines = ibuff;
            }

            if (!string.IsNullOrEmpty(Minutes))
            {
               if (!double.TryParse(Minutes, out dbuff))
               {
                  throw new Exception(string.Format("ConvertTransaction: Minutes [{0}] is not a valid number", Minutes));
               }
               t.Minutes = dbuff;
            }

            if (!string.IsNullOrEmpty(BusinessClass))
            {
               if (BusinessClass.ToUpper().StartsWith("I"))
               {
                  t.BusinessClass = 0;
               }
               else if ((BusinessClass.ToUpper().StartsWith("C"))
                  || (BusinessClass.ToUpper().StartsWith("O")))
               {
                  t.BusinessClass = 1;
               }
               else
               {
                  warningMsgs.Add("BusinessClass: Invalid value " + BusinessClass);
               }
            }

            if (!string.IsNullOrEmpty(CustomerType))
            {
               if (CustomerType.ToUpper().StartsWith("R"))
               {
                  t.CustomerType = 0;
               }
               else if (CustomerType.ToUpper().StartsWith("B"))
               {
                  t.CustomerType = 1;
               }
               else if (CustomerType.ToUpper().StartsWith("I"))
               {
                  t.CustomerType = 2;
               }
               else if (CustomerType.ToUpper().StartsWith("S"))
               {
                  t.CustomerType = 3;
               }
               else
               {
                  warningMsgs.Add("CustomerType: Invalid value " + CustomerType);
               }
            }

            if (!string.IsNullOrEmpty(FacilitiesBased))
            {
               if (CheckBoolTrue(char.ToUpper(FacilitiesBased[0])))
               {
                  t.FacilitiesBased = true;
               }
               else if (CheckBoolFalse(char.ToUpper(FacilitiesBased[0])))
               {
                  t.FacilitiesBased = false;
               }
               else
               {
                  warningMsgs.Add("FacilitiesBased: Invalid value " + FacilitiesBased);
               }
            }

            if (!string.IsNullOrEmpty(Franchise))
            {
               if (CheckBoolTrue(char.ToUpper(Franchise[0])))
               {
                  t.Franchise = true;
               }
               else if (CheckBoolFalse(char.ToUpper(Franchise[0])))
               {
                  t.Franchise = false;
               }
               else
               {
                  warningMsgs.Add("Franchise: Invalid value " + Franchise);
               }
            }

            if (!string.IsNullOrEmpty(Incorporated))
            {
               if (CheckBoolTrue(char.ToUpper(Incorporated[0])))
               {
                  t.Incorporated = true;
               }
               else if (CheckBoolFalse(char.ToUpper(Incorporated[0])))
               {
                  t.Incorporated = false;
               }
               else
               {
                  warningMsgs.Add("Incorporated: Invalid value " + Incorporated);
               }
            }

            if (!string.IsNullOrEmpty(Lifeline))
            {
               if (CheckBoolTrue(char.ToUpper(Lifeline[0])))
               {
                  t.Lifeline = true;
               }
               else if (CheckBoolFalse(char.ToUpper(Lifeline[0])))
               {
                  t.Lifeline = false;
               }
               else
               {
                  warningMsgs.Add("Lifeline: Invalid value " + Lifeline);
               }
            }

            if (!string.IsNullOrEmpty(Regulated))
            {
               if (CheckBoolTrue(char.ToUpper(Regulated[0])))
               {
                  t.Regulated = true;
               }
               else if (CheckBoolFalse(char.ToUpper(Regulated[0])))
               {
                  t.Regulated = false;
               }
               else
               {
                  warningMsgs.Add("Regulated: Invalid value " + Regulated);
               }
            }

            if ((isTelecomReq) && (!string.IsNullOrEmpty(Sale)))
            {
               if ((Sale.ToUpper().StartsWith("S")) ||       //Sale
                  (Sale.ToUpper().StartsWith("RET")) ||     //Retail
                   (CheckBoolTrue(char.ToUpper(Sale[0]))))
               {
                  t.Sale = true;
               }
               else if ((Sale.ToUpper().StartsWith("RES")) ||  //Resale
                  (Sale.ToUpper().StartsWith("W")) ||          //Wholesale
                  (CheckBoolFalse(char.ToUpper(Sale[0]))))
               {
                  t.Sale = false;
               }
               else
               {
                  warningMsgs.Add("Sale: Invalid value " + Sale);
               }

            }

            if (!string.IsNullOrEmpty(ServiceClass))
            {
               if ((ServiceClass.ToUpper().StartsWith("LOCAL")) ||
                  (ServiceClass.ToUpper().StartsWith("OTHER")))
               {
                  t.ServiceClass = 0;
               }
               else if (ServiceClass.ToUpper().StartsWith("LONG"))
               {
                  t.ServiceClass = 1;
               }
               else
               {
                  warningMsgs.Add("ServiceClass: Invalid value " + ServiceClass);
               }
            }

            if (!string.IsNullOrEmpty(CompanyIdentifier))
            {
               t.CompanyIdentifier = CompanyIdentifier;
            }
            if (!string.IsNullOrEmpty(CustomerNumber))
            {
               t.CustomerNumber = CustomerNumber;
            }
            if (!string.IsNullOrEmpty(InvoiceNumber))
            {
               if (!uint.TryParse(InvoiceNumber, out uibuff))
               {
                  throw new Exception(string.Format("ConvertTransaction: InvoiceNumber [{0}] is not a valid number", InvoiceNumber));
               }
               t.InvoiceNumber = uibuff;
            }

         } // end ConvertTransaction()

         public void UpdateJurisdiction(uint p, ZipAddress a, string f, uint n,
            ref uint rp, ref ZipAddress ra, ref string rf, ref uint rn)
         {
            if (p > 0)
            {
               rp = p;
            }
            else if ((a != null) && (!string.IsNullOrWhiteSpace(a.CountryISO)))
            {
               ra = new ZipAddress(a.CountryISO, a.State, a.County, a.Locality, a.ZipCode, a.ZipP4);
            }
            else if (!string.IsNullOrWhiteSpace(f))
            {
               rf = f;
            }
            else if (n > 0)
            {
               rn = n;
            }
            else
            {
               throw new Exception("UpdateJurisdiction - Unexpected exception");
            }
         }

         public bool ConvertTransaction(SalesUseTransaction t)
         {
            return false;
         }

         public RequestTypes GetRequestType(ref string warnMsg)
         {
            if (string.IsNullOrEmpty(RequestType))
            {
               return RequestTypes.CalcTaxes;
            }

            RequestTypes t = RequestTypes.CalcTaxes;
            if (RequestType.ToLower() == "calctaxes")
            {
               t = RequestTypes.CalcTaxes;
            }
            else if (RequestType.ToLower() == "calcadj")
            {
               t = RequestTypes.CalcAdj;
            }
            else if (RequestType.ToLower() == "calcrev")
            {
               t = RequestTypes.CalcRev;
            }
            else if (RequestType.ToLower() == "calcrevadj")
            {
               t = RequestTypes.CalcRevAdj;
            }
            else if (RequestType.ToLower() == "ziplookup")
            {
               t = RequestTypes.ZipLookup;
            }
            else
            {
               warnMsg = "RequestType: Invalid value " + RequestType;
            }

            return t;
         }

         public bool SetField(SaaSBasicTelecomTransFields t, string v)
         {
            if (((int)t <= (int)SaaSBasicTelecomTransFields.Begin) ||
                ((int)t >= (int)SaaSBasicTelecomTransFields.End))
            {
               return false;
            }

            switch (t)
            {
               case SaaSBasicTelecomTransFields.RequestType: RequestType = v; break;

               //BillTo Jurisdiction Fields
               case SaaSBasicTelecomTransFields.BillToPCode: BillToPCode = v; break;
               case SaaSBasicTelecomTransFields.BillToCountryISO: BillToCountryISO = v; break;
               case SaaSBasicTelecomTransFields.BillToState: BillToState = v; break;
               case SaaSBasicTelecomTransFields.BillToCounty: BillToCounty = v; break;
               case SaaSBasicTelecomTransFields.BillToLocality: BillToLocality = v; break;
               case SaaSBasicTelecomTransFields.BillToZipCode: BillToZipCode = v; break;
               case SaaSBasicTelecomTransFields.BillToZipP4: BillToZipP4 = v; break;
               case SaaSBasicTelecomTransFields.BillToFipsCode: BillToFipsCode = v; break;
               case SaaSBasicTelecomTransFields.BillToNpaNxx: BillToNpaNxx = v; break;

               //Origination Jurisdiction Fields
               case SaaSBasicTelecomTransFields.OriginationPCode: OriginationPCode = v; break;
               case SaaSBasicTelecomTransFields.OriginationCountryISO: OriginationCountryISO = v; break;
               case SaaSBasicTelecomTransFields.OriginationState: OriginationState = v; break;
               case SaaSBasicTelecomTransFields.OriginationCounty: OriginationCounty = v; break;
               case SaaSBasicTelecomTransFields.OriginationLocality: OriginationLocality = v; break;
               case SaaSBasicTelecomTransFields.OriginationZipCode: OriginationZipCode = v; break;
               case SaaSBasicTelecomTransFields.OriginationZipP4: OriginationZipP4 = v; break;
               case SaaSBasicTelecomTransFields.OriginationFipsCode: OriginationFipsCode = v; break;
               case SaaSBasicTelecomTransFields.OriginationNpaNxx: OriginationNpaNxx = v; break;

               //Termination Jurisdiction Fields
               case SaaSBasicTelecomTransFields.TerminationPCode: TerminationPCode = v; break;
               case SaaSBasicTelecomTransFields.TerminationCountryISO: TerminationCountryISO = v; break;
               case SaaSBasicTelecomTransFields.TerminationState: TerminationState = v; break;
               case SaaSBasicTelecomTransFields.TerminationCounty: TerminationCounty = v; break;
               case SaaSBasicTelecomTransFields.TerminationLocality: TerminationLocality = v; break;
               case SaaSBasicTelecomTransFields.TerminationZipCode: TerminationZipCode = v; break;
               case SaaSBasicTelecomTransFields.TerminationZipP4: TerminationZipP4 = v; break;
               case SaaSBasicTelecomTransFields.TerminationFipsCode: TerminationFipsCode = v; break;
               case SaaSBasicTelecomTransFields.TerminationNpaNxx: TerminationNpaNxx = v; break;

               //Base Calculation Fields
               case SaaSBasicTelecomTransFields.TransactionType: TransactionType = v; break;
               case SaaSBasicTelecomTransFields.ServiceType: ServiceType = v; break;
               case SaaSBasicTelecomTransFields.Charge: Charge = v; break;
               case SaaSBasicTelecomTransFields.Date: Date = v; break;

               //Extended (Defaultable) Calculation Fields
               case SaaSBasicTelecomTransFields.Lines: Lines = v; break;
               case SaaSBasicTelecomTransFields.Minutes: Minutes = v; break;
               case SaaSBasicTelecomTransFields.BusinessClass: BusinessClass = v; break;
               case SaaSBasicTelecomTransFields.CustomerType: CustomerType = v; break;
               case SaaSBasicTelecomTransFields.FacilitiesBased: FacilitiesBased = v; break;
               case SaaSBasicTelecomTransFields.Franchise: Franchise = v; break;
               case SaaSBasicTelecomTransFields.Incorporated: Incorporated = v; break;
               case SaaSBasicTelecomTransFields.Lifeline: Lifeline = v; break;
               case SaaSBasicTelecomTransFields.Regulated: Regulated = v; break;
               case SaaSBasicTelecomTransFields.Sale: Sale = v; break;
               case SaaSBasicTelecomTransFields.ServiceClass: ServiceClass = v; break;

               // Reporting Fields
               case SaaSBasicTelecomTransFields.CompanyIdentifier: CompanyIdentifier = v; break;
               case SaaSBasicTelecomTransFields.CustomerNumber: CustomerNumber = v; break;
               case SaaSBasicTelecomTransFields.InvoiceNumber: InvoiceNumber = v; break;

               // Zip Lookup Specific Fields
               case SaaSBasicTelecomTransFields.BestMatch: BestMatch = v; break;
               case SaaSBasicTelecomTransFields.LimitResults: LimitResults = v; break;
               case SaaSBasicTelecomTransFields.JurisdictionDetails: JurisdictionDetails = v; break;

            }

            return true;
         }

      } // end public class SaaSBasicTelecomTrans

   } // end public class InputStructs
}



