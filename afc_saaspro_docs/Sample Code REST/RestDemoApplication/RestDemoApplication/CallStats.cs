/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    Benchmark Statistics Class


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System;

namespace Avalara.TestCommon.Benchmark
{
   public class CallStats
   {
      /// <summary>
      /// API call type enumeration.
      /// </summary>
      public enum CallType
      {
         TaxCalculation,
         TaxAdjustment,
         TaxInclusiveCalculation,
         TaxInclusiveAdjustment,
         TransactionSubmission,
         BatchProcessing,
         ZipLookup,
         AvgLatency
      }

      /// <summary>
      /// API call type.
      /// </summary>
      public CallType ApiCallType;

      /// <summary>
      /// Response time for API call.
      /// </summary>
      public TimeSpan TimeSpan;

      /// <summary>
      /// Indicates if the API call returned an error.
      /// </summary>
      public bool Error = false;

      /// <summary>
      /// Number of taxes returned by API call.
      /// </summary>
      public int TaxesReturned = 0;

      /// <summary>
      /// Number of line item taxes returned by batch API call.
      /// </summary>
      public int LineItemTaxes = 0;

      /// <summary>
      /// Number of line items per invoice
      /// </summary>
      public int LineItemPerInvoice = 0;
   }
}
