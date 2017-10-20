/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    Telecom Transaction Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Avalara.TestCommon.APIObjects
{
   [DataContract]
   public class Transaction : BaseTransaction
   {
      #region Data Declarations

      #endregion

      #region Constructor
      public Transaction()
      {

      }
      #endregion
                 

      #region Public Properties
      /// <summary>
      /// Origination Address
      /// </summary>
      [DataMember]
      public ZipAddress OriginationAddress
      {
         get
         {
            return PointAAddress;
         }
         set
         {
            PointAAddress = value;
         }
      }
      /// <summary>
      /// Origination FipsCode
      /// </summary>
      [DataMember]
      public string OriginationFipsCode
      {
         get
         {
            return PointAFipsCode;
         }
         set
         {
            PointAFipsCode = value;
         }
      }
      /// <summary>
      /// Origination PCode
      /// </summary>
      [DataMember]
      public uint? OriginationPCode
      {
         get
         {
            return PointAPCode;
         }
         set
         {
            PointAPCode = value;
         }
      }
      /// <summary>
      /// Origination NpaNxx
      /// </summary>
      [DataMember]
      public uint? OriginationNpaNxx
      {
         get
         {
            return PointANpaNxx;
         }
         set
         {
            PointANpaNxx = value;
         }
      }
      /// <summary>
      /// Termination Address
      /// </summary>
      [DataMember]
      public ZipAddress TerminationAddress
      {
         get
         {
            return PointZAddress;
         }
         set
         {
            PointZAddress = value;
         }
      }
      /// <summary>
      /// Termination FipsCode
      /// </summary>
      [DataMember]
      public string TerminationFipsCode
      {
         get
         {
            return PointZFipsCode;
         }
         set
         {
            PointZFipsCode = value;
         }
      }
      /// <summary>
      /// Termination PCode
      /// </summary>
      [DataMember]
      public uint? TerminationPCode
      {
         get
         {
            return PointZPCode;
         }
         set
         {
            PointZPCode = value;
         }
      }
      /// <summary>
      /// Termination NpaNxx
      /// </summary>
      [DataMember]
      public uint? TerminationNpaNxx
      {
         get
         {
            return PointZNpaNxx;
         }
         set
         {
            PointZNpaNxx = value;
         }
      }
      /// <summary>
      /// Bill to Address
      /// </summary>
      [DataMember]
      public ZipAddress BillToAddress
      {
         get
         {
            return BaseAddress;
         }
         set
         {
            BaseAddress = value;
         }
      }
      /// <summary>
      /// Bill to Fips Code
      /// </summary>
      [DataMember]
      public string BillToFipsCode
      {
         get
         {
            return BaseFipsCode;
         }
         set
         {
            BaseFipsCode = value;
         }
      }
      /// <summary>
      /// Bill to PCode
      /// </summary>
      [DataMember]
      public uint? BillToPCode
      {
         get
         {
            return BasePCode;
         }
         set
         {
            BasePCode = value;
         }
      }
      /// <summary>
      /// Bill to NpaNxx
      /// </summary>
      [DataMember]
      public uint? BillToNpaNxx
      {
         get
         {
            return BaseNpaNxx;
         }
         set
         {
            BaseNpaNxx = value;
         }
      }
      /// <summary>
      /// Indicate if the transaction is a private line transaction - User input
      /// default value it false.
      /// </summary>
      [DataMember]
      public bool? IsPrivateLine { get; set; }

      /// <summary>
      /// The split between the ending points of a private line - User input
      /// If IsPrivateLine is false, this value will be ignored
      /// The valid value should be in [0, 1]
      /// The value indicate how much the portion of charge belongs to the origin user
      /// </summary>
      [DataMember]
      public double? PrivateLineSplit { get; set; }

        /// <summary>
        /// Indicates if the charge of this transaction is tax-inclusive (reverse tax calculation).
        /// </summary>
        [DataMember]
        public bool TaxInclusive
        {
            get { return taxInclusive; }
            set { taxInclusive = value; }
        }

        #endregion

        #region BaseTransaction Public Methods
        // This region has the BaseTransaction Data Members so the order of inclusion is
        // backwards compatible to earlier implementations

        /// <summary>See the EZTaxWebservice User's Manual for valid Customer Types</summary>
        [DataMember]
      public int? CustomerType { get { return TheCustomerType; } set { TheCustomerType = value; } }
      /// <summary>See the EZTaxWebservice User's Manual for valid Customer Types</summary>
      [DataMember]
      public int? BusinessClass { get { return TheBusinessClass; } set { TheBusinessClass = value; } }
      /// <summary>True if this is a sale otherwise false</summary>
      [DataMember]
      public bool Sale { get { return TheSale; } set { TheSale = value; } }
      /// <summary>Transaction Type</summary>
      [DataMember]
      public short TransactionType { get { return TheTransactionType; } set { TheTransactionType = value; } }
      /// <summary>Service Type</summary>
      [DataMember]
      public short ServiceType { get { return TheServiceType; } set { TheServiceType = value; } }
      /// <summary>See the EZTaxWebservice User's Manual for valid Service Classes</summary>
      [DataMember]
      public int? ServiceClass { get { return TheServiceClass; } set { TheServiceClass = value; } }
      /// <summary>Transaction Bill Date.  Field is provided to allow rating and taxing to occur on a date other than Billing Date.</summary>
      [DataMember]
      public DateTime Date { get { return TheDate; } set { TheDate = value; } }
      /// <summary>Charge amount to customer for transaction</summary>
      [DataMember]
      public double Charge { get { return TheCharge; } set { TheCharge = value; } }
      /// <summary>True if this transaction is within an incorporated area of the local jurisdiction, otherwise False.</summary>
      [DataMember]
      public bool Incorporated { get { return TheIncorporated; } set { TheIncorporated = value; } }
      /// <summary>True if Transaction is exempt from Federal Tax, otherwise False</summary>
      [DataMember]
      public bool FederalExempt { get { return TheFederalExempt; } set { TheFederalExempt = value; } }
      /// <summary>True if Transaction is exempt from State Tax, otherwise False </summary>
      [DataMember]
      public bool StateExempt { get { return TheStateExempt; } set { TheStateExempt = value; } }
      /// <summary>True if Transaction is exempt from County Tax, otherwise False</summary>
      [DataMember]
      public bool CountyExempt { get { return TheCountyExempt; } set { TheCountyExempt = value; } }
      /// <summary>True if Transaction is exempt from Local Tax, otherwise False</summary>
      [DataMember]
      public bool LocalExempt { get { return TheLocalExempt; } set { TheLocalExempt = value; } }
      /// <summary>Jurisdiction for Federal Exemption</summary>
      [DataMember]
      public uint FederalPCode { get { return TheFederalPCode; } set { TheFederalPCode = value; } }
      /// <summary>Jurisdiction for State Exemption</summary>
      [DataMember]
      public uint StatePCode { get { return TheStatePCode; } set { TheStatePCode = value; } }
      /// <summary>Jurisdiction for County Exemption</summary>
      [DataMember]
      public uint CountyPCode { get { return TheCountyPCode; } set { TheCountyPCode = value; } }
      /// <summary>Jurisdiction for Local Exemption</summary>
      [DataMember]
      public uint LocalPCode { get { return TheLocalPCode; } set { TheLocalPCode = value; } }
      /// <summary>List of Tax Exemptions</summary>
      [DataMember]
      public List<TaxExemption> Exemptions { get { return TheExemptions; } set { TheExemptions = value; } }
      /// <summary>See the EZTax User's Manual for valid Exemption Types</summary>
      [DataMember]
      public int ExemptionType { get { return TheExemptionType; } set { TheExemptionType = value; } }
      /// <summary>Invoice Number - User Defined</summary>
      [DataMember]
      public uint InvoiceNumber { get { return TheInvoiceNumber; } set { TheInvoiceNumber = value; } }
      /// <summary>User defined value for reporting</summary>
      [DataMember]
      public uint Optional { get { return TheOptional; } set { TheOptional = value; } }
      /// <summary>Customer Number - User Defined</summary>
      [DataMember]
      public string CustomerNumber { get { return TheCustomerNumber; } set { TheCustomerNumber = value; } }
      /// <summary>Customer Identifier - User Defined</summary>
      [DataMember]
      public string CompanyIdentifier { get { return TheCompanyIdentifier; } set { TheCompanyIdentifier = value; } }
      /// <summary>Optional String Value - User Defined</summary>
      [DataMember]
      public string OptionalAlpha1 { get { return TheOptionalAlpha1; } set { TheOptionalAlpha1 = value; } }
      /// <summary>Optional Unsigned Integer Value - User Defined</summary>
      [DataMember]
      public uint Optional4 { get { return TheOptional4; } set { TheOptional4 = value; } }
      /// <summary>Optional Unsigned Integer Value - User Defined</summary>
      [DataMember]
      public uint Optional5 { get { return TheOptional5; } set { TheOptional5 = value; } }
      /// <summary>Optional Unsigned Integer Value - User Defined</summary>
      [DataMember]
      public uint Optional6 { get { return TheOptional6; } set { TheOptional6 = value; } }
      /// <summary>Optional Unsigned Integer Value - User Defined</summary>
      [DataMember]
      public uint Optional7 { get { return TheOptional7; } set { TheOptional7 = value; } }
      /// <summary>Optional Unsigned Integer Value - User Defined</summary>
      [DataMember]
      public uint Optional8 { get { return TheOptional8; } set { TheOptional8 = value; } }
      /// <summary>Optional Unsigned Integer Value - User Defined</summary>
      [DataMember]
      public uint Optional9 { get { return TheOptional9; } set { TheOptional9 = value; } }
      /// <summary>Optional Unsigned Integer Value - User Defined</summary>
      [DataMember]
      public uint Optional10 { get { return TheOptional10; } set { TheOptional10 = value; } }
      /// <summary>See the EZTaxWebservice User's Manual for valid Adjustment Methods</summary>
      [DataMember]
      public int AdjustmentMethod { get { return TheAdjustmentMethod; } set { TheAdjustmentMethod = value; } }
      /// <summary>Number of lines (use with Transaction Type: LOCAL_TYPE and Service Type: LINES)</summary>
      [DataMember]
      public int Lines { get { return TheLines; } set { TheLines = value; } }
      /// <summary>Number of Locations (use with Transaction Type: LOCAL_TYPE and Service Type: LOCATION) </summary>
      [DataMember]
      public int Locations { get { return TheLocations; } set { TheLocations = value; } }
      /// <summary>Minutes of call, set to zero when not appropriate. NOTE: Some taxes are per minute.</summary>
      [DataMember]
      public double Minutes { get { return TheMinutes; } set { TheMinutes = value; } }
      /// <summary>Determines if this is a prepaid debit card transaction.</summary>
      [DataMember]
      public bool Debit { get { return TheDebit; } set { TheDebit = value; } }
      /// <summary>See the EZTaxWebservice User's Manual for valid Discount Types</summary>
      [DataMember]
      public int DiscountType { get { return TheDiscountType; } set { TheDiscountType = value; } }
      /// <summary>Specifies if the carrier delivering the service has company owned facilitiesprovide the service.</summary>
      [DataMember]
      public bool FacilitiesBased { get { return TheFacilitiesBased; } set { TheFacilitiesBased = value; } }
      /// <summary>Indicates if the company provides services sold pursuant to a franchise agreement between the carrier and jurisdiction.</summary>
      [DataMember]
      public bool Franchise { get { return TheFranchise; } set { TheFranchise = value; } }
      /// <summary>Indicates if customer is a Lifeline participant.</summary>
      [DataMember]
      public bool Lifeline { get { return TheLifeline; } set { TheLifeline = value; } }
      /// <summary>True if Regulated, otherwise False</summary>
      [DataMember]
      public bool Regulated { get { return TheRegulated; } set { TheRegulated = value; } }
      /// <summary>Service Level Number - User Defined</summary>
      [DataMember]
      public uint ServiceLevelNumber { get { return TheServiceLevelNumber; } set { TheServiceLevelNumber = value; } }
      /// <summary>List of Exclusions</summary>
      [DataMember]
      public List<Exclusion> Exclusions { get { return TheExclusions; } set { TheExclusions = value; } }
      /// <summary>List of Category Exemptions</summary>
      [DataMember]
      public List<CategoryExemption> CategoryExemptions { get { return TheCategoryExemptions; } set { TheCategoryExemptions = value; } }
      /// <summary>List of optional alphanumeric fields passed in by the client.</summary>
      [DataMember]
      public List<OptionalField> OptionalFields { get { return optionalFields; } set { optionalFields = value; } }

      #endregion

      #region Internal Properties


      #endregion
    }
}
