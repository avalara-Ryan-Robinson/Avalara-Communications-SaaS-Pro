/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    BaseTransaction Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System;
using System.Collections.Generic;

namespace Avalara.TestCommon.APIObjects
{
   public class BaseTransaction
   {

      #region Data Declarations
      internal int? TheCustomerType = null;
      internal int? TheBusinessClass = null;
      internal bool TheSale = false;
      internal short TheTransactionType = 0;
      internal short TheServiceType = 0;
      internal int? TheServiceClass = null;
      internal DateTime TheDate = DateTime.UtcNow;
      internal double TheCharge = 0.00;
      internal bool TheIncorporated = false;
      internal bool TheFederalExempt = false;
      internal bool TheStateExempt = false;
      internal bool TheCountyExempt = false;
      internal bool TheLocalExempt = false;
      internal uint TheFederalPCode = 0;
      internal uint TheStatePCode = 0;
      internal uint TheCountyPCode = 0;
      internal uint TheLocalPCode = 0;
      internal List<TaxExemption> TheExemptions = new List<TaxExemption>();
      internal int TheExemptionType = 0;
      internal uint TheInvoiceNumber = 0;
      internal uint TheOptional = 0;
      internal string TheCustomerNumber = string.Empty;
      internal string TheCompanyIdentifier = string.Empty;
      internal string TheOptionalAlpha1 = string.Empty;
      internal uint TheOptional4 = 0;
      internal uint TheOptional5 = 0;
      internal uint TheOptional6 = 0;
      internal uint TheOptional7 = 0;
      internal uint TheOptional8 = 0;
      internal uint TheOptional9 = 0;
      internal uint TheOptional10 = 0;
      internal int TheAdjustmentMethod = 0;
      internal ZipAddress PointAAddress ;
      internal string PointAFipsCode = string.Empty;
      internal uint? PointAPCode = null;
      internal uint? PointANpaNxx = null;
      internal ZipAddress PointZAddress ;
      internal string PointZFipsCode = string.Empty;
      internal uint? PointZPCode = null;
      internal uint? PointZNpaNxx = null;
      internal ZipAddress BaseAddress;
      internal string BaseFipsCode = string.Empty;
      internal uint? BasePCode = null;
      internal uint? BaseNpaNxx = null;
      internal int TheLines = 0;
      internal int TheLocations = 0;
      internal double TheMinutes = 0;
      internal bool TheDebit = false;
      internal int TheDiscountType = 0;
      internal bool TheFacilitiesBased = false;
      internal bool TheFranchise = false;
      internal bool TheLifeline = false;
      internal bool TheRegulated = false;
      internal uint TheServiceLevelNumber = 0;
      internal uint? taxingJurisdiction = null;
      internal double? baseSaleAmount = null;
      internal bool isAdjustment = false;
      internal bool isReverse = false;
      internal bool isNoTaxTransaction = false;
      internal double? proRatedPct = null;
      protected bool taxInclusive;
      internal List<Exclusion> TheExclusions = new List<Exclusion>();
      internal List<CategoryExemption> TheCategoryExemptions = new List<CategoryExemption>();
      protected List<OptionalField> optionalFields = new List<OptionalField>();

      #endregion

      #region Constructor
      public BaseTransaction()
      {

      }
      #endregion

      #region Internal Properties

      /// <summary>
      /// Taxing jurisdiction for transaction.
      /// </summary>
      internal uint? TaxingJurisdiction
      {
         get { return taxingJurisdiction; }
         set { taxingJurisdiction = value; }
      }

      /// <summary>
      /// Base sale amount calculated by EZTax for reverse tax calculations.
      /// </summary>
      internal double? BaseSaleAmount
      {
         get { return baseSaleAmount; }
         set { baseSaleAmount = value; }
      }

      /// <summary>
      /// Indicates if this transaction is being processed as an adjustment.
      /// </summary>
      internal bool IsAdjustment
      {
         get { return isAdjustment; }
         set { isAdjustment = value; }
      }

      /// <summary>
      /// Indicates if this is a reverse tax calculation.
      /// </summary>
      internal bool IsReverse
      {
         get { return isReverse; }
         set { isReverse = value; }
      }

      /// <summary>
      /// Indicates if this is a no tax transaction.
      /// </summary>
      internal bool IsNoTaxTransaction
      {
         get { return isNoTaxTransaction; }
         set { isNoTaxTransaction = value; }
      }

     

      /// <summary>
      /// Percentage to prorate for prorated tax calculation APIs.
      /// </summary>
      internal double? ProRatedPct
      {
         get { return proRatedPct; }
         set { proRatedPct = value; }
      }

        internal bool? AutoSelectTS { get; set; }

      #endregion
   }
}
