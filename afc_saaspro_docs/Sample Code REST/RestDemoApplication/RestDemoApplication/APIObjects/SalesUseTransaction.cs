/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    SalesUseTransaction Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Avalara.TestCommon.APIObjects
{
    [DataContract]
    [KnownType(typeof(DefaultAttributes))]
    [KnownType(typeof(DemurrageAttributes))]
    [KnownType(typeof(TradeInAttributes))]
    [KnownType(typeof(DepositAttributes))]
    [KnownType(typeof(FreightAttributes))]
    [KnownType(typeof(DiscountAttributes))]
    [KnownType(typeof(FinanceAttributes))]
    [KnownType(typeof(InstallationAttributes))]
    [KnownType(typeof(ShipAndHandlingAttributes))]
    [KnownType(typeof(SoftwareMaintAttributes))]
    [KnownType(typeof(ServiceContractAttributes))]
    [KnownType(typeof(MaintAgreementAttributes))]
    [KnownType(typeof(FactoryWarrantyAttributes))]
    [KnownType(typeof(ExtWarrantyAttributes))]
    public class SalesUseTransaction
    {
        #region Data Declarations
        private int? _customerType = null;
        private int _sale = 0;
        private short _transactionType = 0;
        private short _serviceType = 0;
        private ISaleAttributes _saleAttributes = new DefaultAttributes();
        private DateTime TheDate = DateTime.UtcNow;
        private double _charge = 0.00;
        private bool _incorporated = false;
        private bool _federalExempt = false;
        private bool _stateExempt = false;
        private bool _countyExempt = false;
        private bool _localExempt = false;
        private uint _federalPCode = 0;
        private uint _statePCode = 0;
        private uint _countyPCode = 0;
        private uint _localPCode = 0;
        private List<TaxExemption> _exemptions = new List<TaxExemption>();
        private int _exemptionType = 0;
        private uint _invoiceNumber = 0;
        private uint _optional = 0;
        private string _customerNumber = "";
        private string _companyIdentifier = "";
        private string _optionalAlpha1 = "";
        private uint _optional4 = 0;
        private uint _optional5 = 0;
        private uint _optional6 = 0;
        private uint _optional7 = 0;
        private uint _optional8 = 0;
        private uint _optional9 = 0;
        private uint _optional10 = 0;
        private int _adjustmentMethod = 0;
        private int? _fOB = null;
        private ZipAddress _shipFromAddress = new ZipAddress();
        private string _shipFromFipsCode = "";
        private uint? _shipFromPCode = null;
        private ZipAddress _shipToAddress = new ZipAddress();
        private string _shipToFipsCode = "";
        private uint? _shipToPCode = null;
        private uint? taxingJurisdiction = null;
        private double? baseSaleAmount = null;
        private bool isAdjustment = false;
        private bool isReverse = false;
        private bool isNoTaxTransaction = false;
        private List<CategoryExemption> _categoryExemptions = new List<CategoryExemption>();
        private List<OptionalField> optionalFields = new List<OptionalField>();
        private bool _taxInclusive;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SalesUseTransaction()
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// See the CommsPlatform.API.WrapperClasses User's Manual for valid Customer Types
        /// </summary>
        [DataMember]
        public int? CustomerType
        {
            get
            {
                return _customerType;
            }
            set
            {
                _customerType = value;
            }
        }

        /// <summary>
        /// See the EZTaxBesservice User's Manual for valid SaleOrConsumed values
        /// </summary>
        [DataMember]
        public int? SaleOrConsumed
        {
            get
            {
                return _sale;
            }
            set
            {
                // Do not override value from Sale property unless an actual value is passed in
                if (value.HasValue)
                    _sale = value.Value;
            }
        }

        /// <summary>
        /// True if this is a sale otherwise false
        /// </summary>
        [DataMember]
        public bool Sale
        {
            get
            {
                return _sale > 0;
            }
            set
            {
                _sale = value ? 1 : 0;
            }
        }
        /// <summary>
        /// See the CommsPlatform.API.WrapperClasses User's Manual for valid Transaction Types and valid 
        /// Transaction and Service Type combinations.
        /// </summary>
        [DataMember]
        public short TransactionType
        {
            get
            {
                return _transactionType;
            }
            set
            {
                _transactionType = value;
            }
        }
        /// <summary>
        /// See the CommsPlatform.API.WrapperClasses User's Manual for valid Service Types and valid 
        /// Transaction and Service Type combinations.
        /// </summary>
        [DataMember]
        public short ServiceType
        {
            get
            {
                return _serviceType;
            }
            set
            {
                _serviceType = value;
            }
        }
        /// <summary>
        /// Includes additional information that may effect the rate at which this
        /// transaction is taxed.
        /// </summary>
        [DataMember]
        public ISaleAttributes SaleAttributes
        {
            get
            {
                return _saleAttributes;
            }
            set
            {
                _saleAttributes = value;
            }
        }
        /// <summary>
        /// Transaction Bill Date.  Field is provided to allow rating and taxing to occur on a date other than Billing Date.
        /// </summary>
        [DataMember]
        public DateTime Date
        {
            get
            {
                return TheDate;
            }
            set
            {
                TheDate = value;
            }
        }
        /// <summary>
        /// Charge amount to customer for transaction
        /// </summary>
        [DataMember]
        public double Charge
        {
            get
            {
                return _charge;
            }
            set
            {
                _charge = value;
            }
        }
        /// <summary>
        /// True if this transaction is within an incorporated area of the local jurisdiction, otherwise False.
        /// </summary>
        [DataMember]
        public bool Incorporated
        {
            get
            {
                return _incorporated;
            }
            set
            {
                _incorporated = value;
            }
        }
        /// <summary>
        /// True if Transaction is exempt from Federal Tax, otherwise False
        /// </summary>
        [DataMember]
        public bool FederalExempt
        {
            get
            {
                return _federalExempt;
            }
            set
            {
                _federalExempt = value;
            }
        }
        /// <summary>
        /// True if Transaction is exempt from State Tax, otherwise False 
        /// </summary>
        [DataMember]
        public bool StateExempt
        {
            get
            {
                return _stateExempt;
            }
            set
            {
                _stateExempt = value;
            }
        }
        /// <summary>
        /// True if Transaction is exempt from County Tax, otherwise False
        /// </summary>
        [DataMember]
        public bool CountyExempt
        {
            get
            {
                return _countyExempt;
            }
            set
            {
                _countyExempt = value;
            }
        }
        /// <summary>
        /// True if Transaction is exempt from Local Tax, otherwise False
        /// </summary>
        [DataMember]
        public bool LocalExempt
        {
            get
            {
                return _localExempt;
            }
            set
            {
                _localExempt = value;
            }
        }
        /// <summary>
        /// Jurisdiction for Federal Exemption
        /// </summary>
        [DataMember]
        public uint FederalPCode
        {
            get
            {
                return _federalPCode;
            }
            set
            {
                _federalPCode = value;
            }
        }
        /// <summary>
        /// Jurisdiction for State Exemption
        /// </summary>
        [DataMember]
        public uint StatePCode
        {
            get
            {
                return _statePCode;
            }
            set
            {
                _statePCode = value;
            }
        }
        /// <summary>
        /// Jurisdiction for County Exemption
        /// </summary>
        [DataMember]
        public uint CountyPCode
        {
            get
            {
                return _countyPCode;
            }
            set
            {
                _countyPCode = value;
            }
        }
        /// <summary>
        /// Jurisdiction for Local Exemption
        /// </summary>
        [DataMember]
        public uint LocalPCode
        {
            get
            {
                return _localPCode;
            }
            set
            {
                _localPCode = value;
            }
        }
        /// <summary>
        /// List of Tax Exemptions
        /// </summary>
        [DataMember]
        public List<TaxExemption> Exemptions
        {
            get
            {
                return _exemptions;
            }
            set
            {
                _exemptions = value;
            }
        }
        /// <summary>
        /// List of Category Exemptions
        /// </summary>
        [DataMember]
        public List<CategoryExemption> CategoryExemptions
        {
            get
            {
                return _categoryExemptions;
            }
            set
            {
                _categoryExemptions = value;
            }
        }
        /// <summary>
        /// See the CommsPlatform.API.WrapperClasses User's Manual for valid Exemption Types
        /// </summary>
        [DataMember]
        public int ExemptionType
        {
            get
            {
                return _exemptionType;
            }
            set
            {
                _exemptionType = value;
            }
        }
        /// <summary>
        /// Invoice Number - User Defined
        /// </summary>
        [DataMember]
        public uint InvoiceNumber
        {
            get
            {
                return _invoiceNumber;
            }
            set
            {
                _invoiceNumber = value;
            }
        }
        /// <summary>
        /// User defined value for reporting
        /// </summary>
        [DataMember]
        public uint Optional
        {
            get
            {
                return _optional;
            }
            set
            {
                _optional = value;
            }
        }
        /// <summary>
        /// Customer Number - User Defined
        /// </summary>
        [DataMember]
        public string CustomerNumber
        {
            get
            {
                return _customerNumber;
            }
            set
            {
                _customerNumber = value;
            }
        }
        /// <summary>
        /// Customer Identifier - User Defined
        /// </summary>
        [DataMember]
        public string CompanyIdentifier
        {
            get
            {
                return _companyIdentifier;
            }
            set
            {
                _companyIdentifier = value;
            }
        }
        /// <summary>
        /// Optional String Value - User Defined
        /// </summary>
        [DataMember]
        public string OptionalAlpha1
        {
            get
            {
                return _optionalAlpha1;
            }
            set
            {
                _optionalAlpha1 = value;
            }
        }
        /// <summary>
        /// Optional Unsigned Integer Value - User Defined
        /// </summary>
        [DataMember]
        public uint Optional4
        {
            get
            {
                return _optional4;
            }
            set
            {
                _optional4 = value;
            }
        }
        /// <summary>
        /// Optional Unsigned Integer Value - User Defined
        /// </summary>
        [DataMember]
        public uint Optional5
        {
            get
            {
                return _optional5;
            }
            set
            {
                _optional5 = value;
            }
        }
        /// <summary>
        /// Optional Unsigned Integer Value - User Defined
        /// </summary>
        [DataMember]
        public uint Optional6
        {
            get
            {
                return _optional6;
            }
            set
            {
                _optional6 = value;
            }
        }
        /// <summary>
        /// Optional Unsigned Integer Value - User Defined
        /// </summary>
        [DataMember]
        public uint Optional7
        {
            get
            {
                return _optional7;
            }
            set
            {
                _optional7 = value;
            }
        }
        /// <summary>
        /// Optional Unsigned Integer Value - User Defined
        /// </summary>
        [DataMember]
        public uint Optional8
        {
            get
            {
                return _optional8;
            }
            set
            {
                _optional8 = value;
            }
        }
        /// <summary>
        /// Optional Unsigned Integer Value - User Defined
        /// </summary>
        [DataMember]
        public uint Optional9
        {
            get
            {
                return _optional9;
            }
            set
            {
                _optional9 = value;
            }
        }
        /// <summary>
        /// Optional Unsigned Integer Value - User Defined
        /// </summary>
        [DataMember]
        public uint Optional10
        {
            get
            {
                return _optional10;
            }
            set
            {
                _optional10 = value;
            }
        }
        /// <summary>
        /// See the CommsPlatform.API.WrapperClasses User's Manual for valid Adjustment Methods
        /// </summary>
        [DataMember]
        public int AdjustmentMethod
        {
            get
            {
                return _adjustmentMethod;
            }
            set
            {
                _adjustmentMethod = value;
            }
        }
        /// <summary>
        /// See the CommsPlatform.API.WrapperClasses User's Manual for valid FOB (Freight on Board) values
        /// </summary>
        [DataMember]
        public int? FOB
        {
            get
            {
                return _fOB;
            }
            set
            {
                _fOB = value;
            }
        }
        /// <summary>
        /// Address item was shipped from
        /// </summary>
        [DataMember]
        public ZipAddress ShipFromAddress
        {
            get
            {
                return _shipFromAddress;
            }
            set
            {
                _shipFromAddress = value;
            }
        }
        /// <summary>
        /// FipsCode of location item was shipped from
        /// </summary>
        [DataMember]
        public string ShipFromFipsCode
        {
            get
            {
                return _shipFromFipsCode;
            }
            set
            {
                _shipFromFipsCode = value;
            }
        }
        /// <summary>
        /// PCode of location item was shipped from
        /// </summary>
        [DataMember]
        public uint? ShipFromPCode
        {
            get
            {
                return _shipFromPCode;
            }
            set
            {
                _shipFromPCode = value;
            }
        }
        /// <summary>
        /// Address item was shipped to
        /// </summary>
        [DataMember]
        public ZipAddress ShipToAddress
        {
            get
            {
                return _shipToAddress;
            }
            set
            {
                _shipToAddress = value;
            }
        }
        /// <summary>
        /// FipsCode of location item was shipped to
        /// </summary>
        [DataMember]
        public string ShipToFipsCode
        {
            get
            {
                return _shipToFipsCode;
            }
            set
            {
                _shipToFipsCode = value;
            }
        }
        /// <summary>
        /// PCode of location item was shipped to
        /// </summary>
        [DataMember]
        public uint? ShipToPCode
        {
            get
            {
                return _shipToPCode;
            }
            set
            {
                _shipToPCode = value;
            }
        }

        /// <summary>
        /// Indicates if the charge of this transaction is tax-inclusive (reverse tax calculation).
        /// </summary>
        [DataMember]
        public bool TaxInclusive
        {
            get { return _taxInclusive; }
            set { _taxInclusive = value; }
        }

        /// <summary>
        /// List of optional alphanumeric fields passed in by the client.
        /// </summary>
        [DataMember]
        public List<OptionalField> OptionalFields
        {
            get { return optionalFields; }
            set { optionalFields = value; }
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

        #endregion
    }
}
