/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    CustomerTaxData Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/

namespace Avalara.TestCommon.APIObjects
{
    public class CustomerTaxData
    {
        #region Data Declarations
        private uint _pCode = 0;
        private int _taxType = 0;
        private int? _taxLevel = 0;
        private int _calculationType = 0;
        private double _rate = 0;
        private double _taxAmount = 0;
        private double _exemptSaleAmount = 0;
        private string _description = "";
        private short _surcharge = 0;
        private double _maxBase = 0;
        private double _minBase = 0;
        private double _excessTax = 0;
        private double _totalCharge = 0;
        private short _categoryID = 0;
        private string _categoryDescription = "";
        private int _lines = 0;
        private double _minutes = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CustomerTaxData()
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// PCode for tax.
        /// </summary>
        public uint PCode
        {
            get { return _pCode; }
            set { _pCode = value; }
        }
        /// <summary>
        /// See the CommsPlatform.API.WrapperClasses User's Manual for valid Tax Types
        /// </summary>
        public int TaxType
        {
            get { return _taxType; }
            set { _taxType = value; }
        }
        /// <summary>
        /// See the CommsPlatform.API.WrapperClasses User's Manual for valid Tax Levels
        /// </summary>
        public int? TaxLevel
        {
            get { return _taxLevel; }
            set { _taxLevel = (short)value; }
        }
        /// <summary>
        /// See the CommsPlatform.API.WrapperClasses User's Manual for valid Calculation Types
        /// </summary>
        public int CalculationType
        {
            get { return _calculationType; }
            set { _calculationType = value; }
        }
        /// <summary>
        /// Tax rate or amount applied.
        /// </summary>
      
        public double Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }
        /// <summary>
        /// Tax Amount
        /// </summary>
      
        public double TaxAmount
        {
            get { return _taxAmount; }
            set { _taxAmount = value; }
        }
        /// <summary>
        /// Amount of the charge exempt from taxes.
        /// </summary>
      
        public double ExemptSaleAmount
        {
            get { return _exemptSaleAmount; }
            set { _exemptSaleAmount = value; }
        }
        /// <summary>
        /// Description.
        /// </summary>
      
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// Surcharge flag from tax logic.
        /// </summary>
      
        public short Surcharge
        {
            get { return _surcharge; }
            set { _surcharge = value; }
        }
        /// <summary>
        /// Max amount to which tax is applied.
        /// </summary>
      
        public double MaxBase
        {
            get { return _maxBase; }
            set { _maxBase = value; }
        }
        /// <summary>
        /// Min amount to which tax is applied.
        /// </summary>
      
        public double MinBase
        {
            get { return _minBase; }
            set { _minBase = value; }
        }
        /// <summary>
        /// Rate for Max Base.
        /// </summary>
      
        public double ExcessTax
        {
            get { return _excessTax; }
            set { _excessTax = value; }
        }
        /// <summary>
        /// Total Charge
        /// </summary>
      
        public double TotalCharge
        {
            get { return _totalCharge; }
            set { _totalCharge = value; }
        }
        /// <summary>
        /// Tax category ID.
        /// </summary>
      
        public short CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }
        /// <summary>
        /// Tax Category Description.
        /// </summary>
      
        public string CategoryDescription
        {
            get { return _categoryDescription; }
            set { _categoryDescription = value; }
        }
        /// <summary>
        /// Number of lines (use with Transaction Type: LOCAL_TYPE and Service Type: LINES)
        /// </summary>
      
        public int Lines
        {
            get
            {
                return _lines;
            }
            set
            {
                _lines = value;
            }
        }
        /// <summary>
        /// Minutes of call, set to zero when not appropriate. NOTE: Some taxes are per minute.
        /// </summary>
        public double Minutes
        {
            get
            {
                return _minutes;
            }
            set
            {
                _minutes = value;
            }
        }
        #endregion
    }
}
