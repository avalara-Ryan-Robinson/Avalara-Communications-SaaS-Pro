/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    Benchmark Utilities Class


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Text;

namespace Avalara.TestCommon.Benchmark
{
   public class Util
   {
      /// <summary>
      /// Returns a string with the calculated statistics for the API calls.
      /// </summary>
      /// <param name="threadCount">Number of threads used for processing.</param>
      /// <param name="start">Start time for benchmark run.</param>
      /// <param name="end">End time for benchmark run.</param>
      /// <param name="callStats">Individual call stats for each API call.</param>
      /// <returns>Formatted string containing benchmark stats.</returns>
      public static string GetStats(int threadCount, DateTime start, DateTime end, ConcurrentBag<CallStats> callStats, ConcurrentBag<CallStats> pingCheck)
      {
         var sb = new StringBuilder();

         callStats.GroupBy(s => s.ApiCallType).ToList().ForEach(group =>
         {
            if (sb.Length > 0)
               sb.AppendLine();
            switch (group.Key)
            {
               case CallStats.CallType.TaxCalculation:
                  sb.AppendLine("Call type: Tax calculation");
                  break;
               case CallStats.CallType.TaxAdjustment:
                  sb.AppendLine("Call type: Tax adjustment calculation");
                  break;
               case CallStats.CallType.TaxInclusiveCalculation:
                  sb.AppendLine("Call type: Tax inclusive calculation");
                  break;
               case CallStats.CallType.TaxInclusiveAdjustment:
                  sb.AppendLine("Call type: Tax inclusive adjustment calculation");
                  break;
               case CallStats.CallType.TransactionSubmission:
                  sb.AppendLine("Call type: Transaction submission (customer mode)");
                  break;
               case CallStats.CallType.BatchProcessing:
                  sb.AppendLine("Call type: Batch processing (invoice mode)");
                  break;
               case CallStats.CallType.ZipLookup:
                  sb.AppendLine("Call type: Zip Lookup processing");
                  break;
               case CallStats.CallType.AvgLatency:
                  sb.AppendLine("Call type: Average latency");
                  break;
               default:
                  sb.AppendLine("Call type: Not specified");
                  break;

            }
            sb.AppendLine();

            var groupStats = group.ToList();
            var transCount = groupStats.Count;
            var taxCount = groupStats.Sum(s => s.TaxesReturned);
            var lineItems = groupStats.Sum(s => s.LineItemPerInvoice);
            var lineItemsPerInvoice = (transCount == 0) ? 0 : lineItems / transCount;
            var lineItemTaxCount = groupStats.Sum(s => s.LineItemTaxes);
            var errCount = groupStats.Count(s => s.Error);
            var timeElapsed = end - start;
            var transactionsPerSecond = transCount / timeElapsed.TotalSeconds;

            groupStats = groupStats.OrderBy(s => s.TimeSpan).ToList();
            var min = new TimeSpan(groupStats.Min(s => s.TimeSpan.Ticks));
            var max = new TimeSpan(groupStats.Max(s => s.TimeSpan.Ticks));
            var average = new TimeSpan((long)groupStats.Average(s => s.TimeSpan.Ticks));

            sb.AppendLine(string.Format("Threads:                        {0}", threadCount));
            sb.AppendLine(string.Format("Calls Made:                     {0}", transCount));
            if (group.Key == CallStats.CallType.ZipLookup)
            {
               sb.AppendLine(string.Format("Total Locations Returned        {0}", taxCount));
            }
            else
            {
               sb.AppendLine(string.Format("Total Taxes Returned            {0}", taxCount));
            }
            if (group.Key == CallStats.CallType.BatchProcessing)
            {
               sb.AppendLine(string.Format("Line Items Per Invoice/Total:   {0}/{1}", lineItemsPerInvoice, lineItems));
               sb.AppendLine(string.Format("Total Line Item Taxes Returned  {0}", lineItemTaxCount));
            }
            sb.AppendLine(string.Format("Errors:                         {0}", errCount));
            sb.AppendLine(string.Format("Start Time:                     {0}", start.ToString()));
            sb.AppendLine(string.Format("End Time:                       {0}", end.ToString()));
            sb.AppendLine(string.Format("Time Elapsed:                   {0}", timeElapsed));
            sb.AppendLine(string.Format("Calls Per Hour:                 {0}", transactionsPerSecond * 60 * 60));
            sb.AppendLine(string.Format("Calls Per Minute:               {0}", transactionsPerSecond * 60));
            sb.AppendLine(string.Format("Calls Per Second:               {0}", transactionsPerSecond));

            sb.AppendLine(string.Format("Minimum Call Duration:          {0}", min));

            // Output percentiles
            for (int percentile = 10; percentile <= 90; percentile += 10)
            {
               var percentileIdx = (int)((groupStats.Count / 100d) * percentile);
               sb.AppendLine(string.Format("{0}th percentile:                {1}", percentile,
                   groupStats[percentileIdx].TimeSpan));
            }

            sb.AppendLine(string.Format("Maximum Call Duration:          {0}", max));
            sb.AppendLine(string.Format("Average Call Duration:          {0}", average));

            // Calculate standard deviation
            double sqdDiff = 0;
            groupStats.ForEach(s => sqdDiff += Math.Pow(s.TimeSpan.Ticks - average.Ticks, 2));
            var variance = sqdDiff / groupStats.Count;
            var stdDev = Math.Sqrt(variance);

            sb.AppendLine(string.Format("Standard Deviation:             {0}", new TimeSpan((long)stdDev)));
         });

         sb.AppendLine("    ");

         pingCheck.GroupBy(s => s.ApiCallType).ToList().ForEach(group =>
         {
            var groupStats = group.ToList();
            var average = new TimeSpan((long)groupStats.Average(s => s.TimeSpan.Ticks));
            var min = new TimeSpan(groupStats.Min(s => s.TimeSpan.Ticks));
            var max = new TimeSpan(groupStats.Max(s => s.TimeSpan.Ticks));

            sb.AppendLine(string.Format("Minimum Ping Duration(Health):  {0}", min));
            sb.AppendLine(string.Format("Maximum Ping Duration(Health):  {0}", max));
            sb.AppendLine(string.Format("Average Ping Duration(Health):  {0}", average));
         });

         return sb.ToString();
      }

      /// <summary>
      /// Writes the individual call stats to a CSV file.
      /// </summary>
      /// <param name="dir">Output directory.</param>
      /// <param name="fileName">Output file name without path and extension.</param>
      /// <param name="callStats">Call stats.</param>
      public static void WriteIndividualStats(string dir, string fileName, ConcurrentBag<CallStats> callStats)
      {
         int fileSuffix = 0;
         fileName += " - " + DateTime.Today.ToString("yyyyMMdd");
         var ext = ".csv";
         var outputFileName = Path.Combine(dir, fileName + ext);

         // Make sure file name is unique.
         while (File.Exists(outputFileName))
         {
            fileSuffix++;
            outputFileName = Path.Combine(dir, fileName + " - " + fileSuffix + ext);
         }

         using (var logFile = System.IO.File.Create(outputFileName))
         {
            using (var writer = new StreamWriter(logFile))
            {
               // Write header
               writer.WriteLine("ApiCallType,Microseconds,TaxesReturned,Error");

               // Write detail
               callStats.ToList().ForEach(s => writer.WriteLine("{0},{1},{2},{3}",
                   s.ApiCallType, (int)(s.TimeSpan.TotalMilliseconds * 1000), s.TaxesReturned, s.Error));
            }
         }
      }

      /// <summary>
      /// Writes the individual call stats to a CSV file.
      /// </summary>
      /// <param name="dir">Output directory.</param>
      /// <param name="fileName">Output file name without path and extension.</param>
      /// <param name="callStats">Call stats.</param>
      public static void WriteErrorMessage(string dir, string fileName, string errMsg)
      {
         int fileSuffix = 0;
         fileName += " - " + DateTime.Today.ToString("yyyyMMdd");
         var ext = ".json";
         var outputFileName = Path.Combine(dir, fileName + ext);

         // Make sure file name is unique.
         while (File.Exists(outputFileName))
         {
            fileSuffix++;
            outputFileName = Path.Combine(dir, fileName + " - " + fileSuffix + ext);
         }

         using (var logFile = System.IO.File.Create(outputFileName))
         {
            using (var writer = new StreamWriter(logFile))
            {
               // Write header
               writer.WriteLine(errMsg);
            }
         }
      }
   }
}
