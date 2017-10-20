/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    Benchmark methods Rest Demo Application processing


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Avalara.TestCommon.APIObjects;
using Avalara.TestCommon.Common;
using Avalara.TestCommon.ServerSetup;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;
using static Avalara.RestDemoApplication.TestingWindow;
using System.Diagnostics;
using Avalara.TestCommon.DataSetup;
using Avalara.RestDemoApplication;

namespace Avalara.TestCommon.Benchmark
{
   public class BenchmarkSettings
   {
      public const int MAX_GENERATED_TEST_COUNT = 50000;
      public const int MAX_TEST_COUNT = 100000;
      public const int MS_TO_NS = 1000000;

      public string DefaultCompanyIdentifier;
      public string DefaultCustomerNumber;
      public short DefaultTransactionType;
      public short DefaultServiceType;
      public double DefaultCharge;
      public DateTime DefaultInvoiceDate;
      public uint DefaultPCode;

      public EnumeratedTypes.TestCalculationTypes CalcType;
      public int Threads;

      public List<Transaction> Transactions = null;
      public int TestRange = 0;
      public DemoStatus Status = null;

      public string WorkingDirectory;

      public BenchmarkSettings(
         string companyIdentifier,
         string custNo,
         string transactionType,
         string serviceType,
         string charge,
         DateTime date,
         string pcode,
         EnumeratedTypes.TestCalculationTypes calcType,
         int threads,
         string workingDirectory)
      {
         DefaultCompanyIdentifier = companyIdentifier;
         DefaultCustomerNumber = custNo;
         if (!short.TryParse(transactionType, out DefaultTransactionType))
         {
            throw new Exception(string.Format("Default transaction type {0} is not valid short value", transactionType));
         }
         if (!short.TryParse(serviceType, out DefaultServiceType))
         {
            throw new Exception(string.Format("Default service type {0} is not valid short value", serviceType));
         }
         if (!double.TryParse(charge, out DefaultCharge))
         {
            throw new Exception(string.Format("Default charge {0} is not valid double value", charge));
         }
         DefaultInvoiceDate = date;
         if (!uint.TryParse(pcode, out DefaultPCode))
         {
            throw new Exception(string.Format("Default pcode {0} is not valid unsigned int value", pcode));
         }
         CalcType = calcType;
         Threads = threads;
         WorkingDirectory = workingDirectory;
      }
   }

   public class TelecomBenchmark
   {
      internal static Transaction TransactionItem = null;
      internal static Random rnd = new Random(DateTime.Now.Millisecond);

      public TelecomBenchmark()
      {
         TransactionItem = GetTransaction(0, 0, 0, DateTime.Today, 100.0, "DEMO", "REST API");
      }

      public string GetRESTVersion(out bool success)
      {
         string ResultText = string.Empty;
         success = false;
         try
         {
            var client = new CommsPlatformRestApi();
            var response = client.GetAsync($"api/v1/Application/RESTVersion").Result;
            ResultText = response.Content.ReadAsStringAsync().Result;
            success = response.IsSuccessStatusCode;
         }
         catch (Exception ex)
         {
            ResultText = ex.Message;
         }

         return ResultText;
      }

      internal static Transaction GetTransaction(int idx, BenchmarkSettings settings)
      {
         Transaction t = null;
         switch (settings.Status.TestType)
         {
            case TestTypes.COUNT_TEST:
            case TestTypes.TIMED_TEST:
               t = TransactionItem;
               InputCannedData.TSPair tspair = InputCannedData.TSPairs[rnd.Next(InputCannedData.TSPairs.Count - 1)];
               t.TerminationPCode = t.OriginationPCode = t.TerminationPCode = InputCannedData.PCodes[rnd.Next(InputCannedData.PCodes.Count - 1)];
               t.TransactionType = (short)tspair.TransType;
               t.ServiceType = (short)tspair.ServiceType;
               t.InvoiceNumber = (uint)idx;
               break;
            case TestTypes.FILE_TEST:
               t = settings.Transactions[idx % settings.Transactions.Count];
               break;
         }

         return t;
      }

      /// <summary>Processes sample telecom transaction using AFC SaaS Pro Rest tax calculation call .</summary>
      /// <param name="settings">Settings to be used for tax calculation / benchmark</param>
      /// <returns>String with tax data or exception message (as applicable)</returns>
      public string RunSingleTransaction(BenchmarkSettings settings)
      {
         string ResultText = string.Empty;
         try
         {
            var trans = GetTransaction(settings.DefaultPCode, settings.DefaultTransactionType, settings.DefaultServiceType,
               settings.DefaultInvoiceDate, settings.DefaultCharge, settings.DefaultCompanyIdentifier, settings.DefaultCustomerNumber);
            var client = new CommsPlatformRestApi();
            TaxData[] taxes = null;

            var response = client.PostAsJson($"api/v1/CalculateTaxes", trans).Result;
            if (response.IsSuccessStatusCode)
            {
               var content = response.Content.ReadAsStringAsync().Result;
               ResultText = JValue.Parse(content).ToString(Formatting.Indented);
               taxes = JsonConvert.DeserializeObject<TaxData[]>(ResultText);
            }

         }
         catch (Exception ex)
         {
            ResultText = ex.Message;
         }

         return ResultText;
      }

      // Test routine for calibrating tick logic for update of graph and run time fields
      static void TestTicks(DemoStatus stat)
      {
         for (int threads = 1; threads < 100; threads *= 2)
         {
            stat.ResetTicks();
            stat.SetTicks(threads, 100);
            stat.SetTicks(threads, 1000);
            stat.SetTicks(threads, 5000);
            stat.SetTicks(threads, 10000);
            stat.SetTicks(threads, 20000);
            stat.SetTicks(threads, 50000);
            stat.SetTicks(threads, 250000);
         }
      }

      /// <summary>Processes telecom transactions using AFC SaaS Pro Rest tax calculation calls for gathering performance statistics.</summary>
      /// <param name="settings">Settings to be used for tax calculation / benchmark</param>
      /// <returns>String with overall summarized benchmark metrics for run</returns>
      public static int RunBenchmark(BenchmarkSettings settings)
      {
         List<Transaction> transactionList = settings.Transactions;
         int transactionCount = settings.Status.GetTransactionCount();
         TestTypes tt = settings.Status.TestType;
         if (tt == TestTypes.FILE_TEST)
         {
            if ((transactionList == null) || (transactionList.Count == 0) || (transactionCount == 0))
            {
               throw new Exception("Transaction list for file input test cannot be null or empty");
            }
         }
         else if (tt == TestTypes.TIMED_TEST)
         {
            transactionCount = Int32.MaxValue;
         }

            // Load configuration options
         var opts = new ParallelOptions { MaxDegreeOfParallelism = settings.Threads };
         var client = new CommsPlatformRestApi();

         CallStats.CallType apiCallType = CallStats.CallType.TaxCalculation;
         string api = $"api/v1/CalculateTaxes";
         switch (settings.CalcType)
         {
            case EnumeratedTypes.TestCalculationTypes.StdAdjustments:
               api = $"api/v1/CalculateAdjustments";
               apiCallType = CallStats.CallType.TaxAdjustment;
               break;
            case EnumeratedTypes.TestCalculationTypes.TaxInclusive:
               api = $"api/v1/CalculateTaxInclusive/Taxes";
               apiCallType = CallStats.CallType.TaxInclusiveCalculation;
               break;
            case EnumeratedTypes.TestCalculationTypes.TaxInclusiveAdjustment:
               api = $"api/v1/CalculateTaxInclusive/Adjustments";
               apiCallType = CallStats.CallType.TaxInclusiveAdjustment;
               break;
         }

         double totApiTimeMillisecs = 0.0;
         var startRealTime = DateTime.UtcNow;
         settings.Status.TestWin.SetStartTime(startRealTime);
         settings.Status.TestWin.InitAPIStats();
         settings.Status.StartTimer(0);
         settings.Status.ResetTicks();

         int transactionsProcessed = 0;
         Parallel.For(0, transactionCount, opts, (idx, loopState) =>
         {
            if (TestingWindow.CancelBenchmark) { loopState.Stop(); return;  }
            if (TestingWindow.FinishedBenchmark) { loopState.Stop();}

            Transaction trans = GetTransaction(transactionsProcessed, settings);

            //Set default values if not supplied in input file
            if (settings.Status.TestType == TestTypes.FILE_TEST)
            {
               if (trans.Charge == 0.0) trans.Charge = settings.DefaultCharge;
               if (string.IsNullOrEmpty(trans.CompanyIdentifier)) trans.CompanyIdentifier = settings.DefaultCompanyIdentifier;
               if (trans.Date == null) trans.Date = settings.DefaultInvoiceDate;
               if (trans.TransactionType == 0) trans.TransactionType = settings.DefaultTransactionType;
               if (trans.ServiceType == 0) trans.ServiceType = settings.DefaultServiceType;
            }

            switch (apiCallType)
            {
               case CallStats.CallType.TaxCalculation:
                  trans.TaxInclusive = false;
                  trans.IsAdjustment = false;
                  break;
               case CallStats.CallType.TaxAdjustment:
                  trans.TaxInclusive = false;
                  trans.IsAdjustment = true;
                  break;
               case CallStats.CallType.TaxInclusiveCalculation:
                  trans.TaxInclusive = true;
                  trans.IsAdjustment = false;
                  break;
               case CallStats.CallType.TaxInclusiveAdjustment:
                  trans.TaxInclusive = true;
                  trans.IsAdjustment = true;
                  break;

            }

            transactionsProcessed++;
            Stopwatch apiStopWatch = new Stopwatch();
            try
            {
               int numOfTaxes = 0;
               apiStopWatch.Start();
               var response = client.PostAsJson(api, trans).Result;
               apiStopWatch.Stop();
               if (response.IsSuccessStatusCode)
               {
                  var content = response.Content.ReadAsStringAsync().Result;
                  if (trans.TaxInclusive)
                  {
                     ReverseTaxResults inclTaxes = JsonConvert.DeserializeObject<ReverseTaxResults>(content);
                     if ((inclTaxes != null) && (inclTaxes.Taxes != null)) numOfTaxes = inclTaxes.Taxes.Count;
                  }
                  else
                  {
                     TaxData[] taxes = JsonConvert.DeserializeObject<TaxData[]>(content);
                     if (taxes != null) numOfTaxes = taxes.Length;
                  }
               }

               if (TestingWindow.CancelBenchmark) { loopState.Stop(); return; }
               if (TestingWindow.FinishedBenchmark) { loopState.Stop(); }

               settings.Status.DemoTimeSpan += apiStopWatch.Elapsed;
               totApiTimeMillisecs += apiStopWatch.ElapsedMilliseconds;

               if (tt != TestTypes.TIMED_TEST)
               {
                  settings.Status.TestWin.IncrementBenchmarkProgressBar(1);
               }

               settings.Status.SetTicks(settings.Threads, transactionsProcessed);
               if (settings.Status.TestSmallTick(transactionsProcessed))
               {
                  settings.Status.TestWin.UpdateAPIStats(transactionsProcessed, totApiTimeMillisecs);
               }

               if (settings.Status.TestLargeTick(transactionsProcessed))
                  {
                     settings.Status.DemoChart.AddChartPoint(transactionsProcessed, (int)apiStopWatch.Elapsed.TotalMilliseconds);
               }

            }
            catch (Exception)
            {
               if (TestingWindow.CancelBenchmark) { loopState.Stop(); return; }
               var end = DateTime.Now;
               settings.Status.TestWin.IncrementBenchmarkProgressBar(1);
             } // end catch
         }); // end Parallel.For loop

         if (settings.Status.TestType != TestTypes.TIMED_TEST)
         {
            settings.Status.TestWin.IncrementBenchmarkProgressBar(1);
         }
         else
         {
            transactionCount = transactionsProcessed;
         }
         settings.Status.EndTimedDemo();
         settings.Status.TestWin.UpdateAPIStats(transactionCount, totApiTimeMillisecs);
         settings.Status.TestWin.JoinThread();
         var endRealTime = DateTime.UtcNow;
         settings.Status.TestWin.SetEndTime(endRealTime);
         TimeSpan realTimeSpan = endRealTime - startRealTime;
         settings.Status.TestWin.FinalizeAPIStats(transactionCount, realTimeSpan);
         client.Dispose();
         return transactionCount;
      }

      public static List<Transaction> GetRandomTransactions(int cnt)
      {
         List<Transaction> list = new List<Transaction>();

         if (cnt <= 0) cnt = BenchmarkSettings.MAX_GENERATED_TEST_COUNT;

         Random rnd = new Random(cnt);
         int maxPCode = InputCannedData.PCodes.Count-1;
         int maxTSPair = InputCannedData.TSPairs.Count-1;

         Transaction t = GetTransaction(0, 0, 0, DateTime.Today, 100.0, "DEMO", "REST API");
         for (int idx=0; idx<cnt; idx++)
         {
            uint pcode = InputCannedData.PCodes[rnd.Next(maxPCode)];
            InputCannedData.TSPair tspair = InputCannedData.TSPairs[rnd.Next(maxTSPair)];
            t.TerminationPCode = t.OriginationPCode = t.TerminationPCode = pcode;
            t.TransactionType = (short)tspair.TransType;
            t.ServiceType = (short)tspair.ServiceType;
            t.InvoiceNumber = (uint)idx;
            list.Add(t);
         }

         return list;
      }

      /// <summary>
      /// Creates a Transaction object.
      /// </summary>
      /// <param name="pcode">PCode.</param>
      /// <param name="trans">Transaction ID.</param>
      /// <param name="serv">Service ID.</param>
      /// <returns></returns>
      public static Transaction GetTransaction(uint pcode, short trans, short serv, 
         DateTime transDate, double charge, string companyIdentifier, string cust_num)
      {
         return new Transaction
         {
            AdjustmentMethod = 0,
            BusinessClass = 1,
            Charge = charge,
            CountyExempt = false,
            CustomerType = 0,
            Date = transDate,
            Debit = false,
            FacilitiesBased = false,
            FederalExempt = false,
            Franchise = false,
            Incorporated = true,
            Lifeline = false,
            Lines = 1,
            LocalExempt = false,
            Locations = 1,
            Minutes = 10,
            Regulated = true,
            Sale = true,
            ServiceClass = 0,
            StateExempt = false,
            OriginationPCode = pcode,
            TerminationPCode = pcode,
            BillToPCode = pcode,
            TransactionType = trans,
            ServiceType = serv,
            Optional10 = Convert.ToUInt32(transDate.ToString("yyyyMM")),
            CompanyIdentifier = companyIdentifier,
            CustomerNumber = cust_num
         };
      }

      public ZipLookupRequest ConvertZipAddressToZipLookupRequest(ZipAddress zipAddr, bool bestMatchFlag, int resultLimit)
      {
         ZipLookupRequest ziplkup = new ZipLookupRequest
         {
            CountryIso = zipAddr.CountryISO,
            State = zipAddr.State,
            County = zipAddr.County,
            City = zipAddr.Locality,
            ZipCode = zipAddr.ZipCode,
            BestMatch = bestMatchFlag,
            JurisdictionDetails = true,
            LimitResults = resultLimit
         };

         return ziplkup;

      }

      public static void ProcessRequestAsThread(object p)
      {
         try
         {
            BenchmarkSettings settings = (BenchmarkSettings)p;
            int apiCallCount = TelecomBenchmark.RunBenchmark(settings);
            settings.Status.EndTimedDemo();
         }
         catch (Exception ex)
         {
            if ((!TestingWindow.CancelBenchmark) && (!TestingWindow.AbortBenchmark))
            {
               throw;
            }
         }

      }


   }
}
