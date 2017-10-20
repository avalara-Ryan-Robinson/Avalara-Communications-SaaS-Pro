/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    TaxData Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Collections.Generic;

namespace Avalara.TestCommon.APIObjects
{
     public class TaxData             
    {
        #region Data Declarations
        private int         TheAdjustmentType      = 0;
        private bool        TheBillable            = false;
        private int         TheCalculationType     = 0;
        private string      TheCategoryDescription = "";
        private short       TheCategoryID          = 0;
        private string      TheCompanyIdentifier   = "";
        private bool        TheCompliance          = false; 
        private string      TheCustomerNumber      = "";
        private string      TheDescription         = "";
        private int         TheExemptionType       = 0;
        private double      TheExemptSaleAmount    = 0;
        private uint        TheInvoiceNumber       = 0;
        private uint        TheOptional            = 0;
        private uint        TheOptional10          = 0;
        private uint        TheOptional4           = 0;
        private uint        TheOptional5           = 0;
        private uint        TheOptional6           = 0;
        private uint        TheOptional7           = 0;
        private uint        TheOptional8           = 0;
        private uint        TheOptional9           = 0;
        private string      TheOptionalAlpha1      = "";
        private uint        ThePCode               = 0;
        private double      TheRate                = 0;
        private double      TheRefundUncollect     = 0;
        private uint        TheServiceLevelNumber  = 0;
        private bool        TheSurcharge           = false;
        private double      TheTaxableMeasure      = 0;
        private double      TheTaxAmount           = 0;
        private int?        TheTaxLevel            = null;
        private short       TheTaxType             = 0;
        private int         TheLines               = 0;
        private double      TheMinutes             = 0;
        private List<OptionalField> optionalFields = new List<OptionalField>();
        #endregion

        #region Constructor
        public TaxData ()                       
        {

        }
       
        #endregion

        #region Public Properties
        /// <summary>
        /// See the EZTaxWebservice User's Manual for valid Adjustment Types
        /// </summary>
         public int    AdjustmentType      
        {
            get
            {
                return TheAdjustmentType;
            }
            set
            {
                TheAdjustmentType = value;
            }
        }
        /// <summary>
        /// Billable flag from tax logic.
        /// </summary>
         public bool   Billable            
        {
            get
            {
                return TheBillable;
            }
            set
            {
                TheBillable = value;
            }
        }
        /// <summary>
        /// See the EZTaxWebservice User's Manual for valid Calculation Types
        /// </summary>
         public int    CalculationType     
        {
            get
            {
                return TheCalculationType;
            }
            set
            {
                TheCalculationType = value;
            }
        }
        /// <summary>
        /// Tax Category Description.
        /// </summary>
         public string CategoryDescription 
        {
            get
            {
                return TheCategoryDescription;
            }
            set
            {
                TheCategoryDescription = value;
            }
        }
        /// <summary>
        /// Tax category ID.
        /// </summary>
         public short  CategoryID          
        {
            get
            {
                return TheCategoryID;
            }
            set
            {
                TheCategoryID = value;
            }
        }
        /// <summary>
        /// Customer Identifier - User Defined
        /// </summary>
         public string CompanyIdentifier   
        {
            get
            {
                return TheCompanyIdentifier;
            }
            set
            {
                TheCompanyIdentifier = value;
            }
        }
        /// <summary>
        /// Compliance flag from tax logic.
        /// </summary>
         public bool   Compliance          
        {
            get
            {
                return TheCompliance;
            }
            set
            {
                TheCompliance = value;
            }
        }
        /// <summary>
        /// Customer Number - User Defined
        /// </summary>
         public string CustomerNumber      
        {
            get
            {
                return TheCustomerNumber;
            }
            set
            {
                TheCustomerNumber = value;
            }
        }
        /// <summary>
        /// Tax description.
        /// </summary>
         public string Description         
        {
            get
            {
                return TheDescription;
            }
            set
            {
                TheDescription = value;
            }
        }
        /// <summary>
        /// See the EZTaxWebservice User's Manual for valid Exemption Types
        /// </summary>
         public int    ExemptionType       
        {
            get
            {
                return TheExemptionType;
            }
            set
            {
                TheExemptionType = value;
            }
        }
        /// <summary>
        /// Amount of the charge exempt from taxes.
        /// </summary>
         public double ExemptSaleAmount    
        {
            get
            {
                return TheExemptSaleAmount;
            }
            set
            {
                TheExemptSaleAmount = value;
            }
        }
        /// <summary>
        /// Invoice Number - User Defined
        /// </summary>
         public uint   InvoiceNumber       
        {
            get
            {
                return TheInvoiceNumber;
            }
            set
            {
                TheInvoiceNumber = value;
            }
        }
        /// <summary>
        /// User defined value for reporting
        /// </summary>
         public uint   Optional            
        {
            get
            {
                return TheOptional;
            }
            set
            {
                TheOptional = value;
            }
        }
        /// <summary>
        /// Optional String Value - User Defined
        /// </summary>
         public string OptionalAlpha1      
        {
            get
            {
                return TheOptionalAlpha1;
            }
            set
            {
                TheOptionalAlpha1 = value;
            }
        }
        /// <summary>
        /// Optional Unsigned Integer Value - User Defined
        /// </summary>
         public uint   Optional4           
        {
            get
            {
                return TheOptional4;
            }
            set
            {
                TheOptional4 = value;
            }
        }
        /// <summary>
        /// Optional Unsigned Integer Value - User Defined
        /// </summary>
         public uint   Optional5           
        {
            get
            {
                return TheOptional5;
            }
            set
            {
                TheOptional5 = value;
            }
        }
        /// <summary>
        /// Optional Unsigned Integer Value - User Defined
        /// </summary>
         public uint   Optional6           
        {
            get
            {
                return TheOptional6;
            }
            set
            {
                TheOptional6 = value;
            }
        }
        /// <summary>
        /// Optional Unsigned Integer Value - User Defined
        /// </summary>
         public uint   Optional7           
        {
            get
            {
                return TheOptional7;
            }
            set
            {
                TheOptional7 = value;
            }
        }
        /// <summary>
        /// Optional Unsigned Integer Value - User Defined
        /// </summary>
         public uint   Optional8           
        {
            get
            {
                return TheOptional8;
            }
            set
            {
                TheOptional8 = value;
            }
        }
        /// <summary>
        /// Optional Unsigned Integer Value - User Defined
        /// </summary>
         public uint   Optional9           
        {
            get
            {
                return TheOptional9;
            }
            set
            {
                TheOptional9 = value;
            }
        }
        /// <summary>
        /// Optional Unsigned Integer Value - User Defined
        /// </summary>
         public uint   Optional10          
        {
            get
            {
                return TheOptional10;
            }
            set
            {
                TheOptional10 = value;
            }
        }
        /// <summary>
        /// PCode for tax.
        /// </summary>
         public uint   PCode               
        {
            get
            {
                return ThePCode;
            }
            set
            {
                ThePCode = value;
            }
        }
        /// <summary>
        /// Tax rate or amount applied.
        /// </summary>
         public double Rate                
        {
            get
            {
                return TheRate;
            }
            set
            {
                TheRate = value;
            }
        }
        /// <summary>
        /// Taxable measure if tax is smaller than 0.
        /// </summary>
         public double RefundUncollect     
        {
            get
            {
                return TheRefundUncollect;
            }
            set
            {
                TheRefundUncollect = value;
            }
        }
        /// <summary>
        /// Service Level Number - User Defined
        /// </summary>
         public uint   ServiceLevelNumber  
        {
            get
            {
                return TheServiceLevelNumber;
            }
            set
            {
                TheServiceLevelNumber = value;
            }
        }
        /// <summary>
        /// Surcharge flag from tax logic.
        /// </summary>
         public bool   Surcharge           
        {
            get
            {
                return TheSurcharge;
            }
            set
            {
                TheSurcharge = value;
            }
        }
        /// <summary>
        /// Amount of Charge plus any taxed taxes.
        /// </summary>
         public double TaxableMeasure      
        {
            get
            {
                return TheTaxableMeasure;
            }
            set
            {
                TheTaxableMeasure = value;
            }
        }
        /// <summary>
        /// Calculated tax amount.
        /// </summary>
         public double TaxAmount           
        {
            get
            {
                return TheTaxAmount;
            }
            set
            {
                TheTaxAmount = value;
            }
        }
        /// <summary>
        /// See the EZTaxWebservice User's Manual for valid Tax Levels
        /// </summary>
         public int?   TaxLevel            
        {
            get
            {
                return TheTaxLevel;
            }
            set
            {
                TheTaxLevel = value;
            }
        }
        /// <summary>
        /// See the EZTaxWebservice User's Manual for valid Tax Types
        /// </summary>
         public short  TaxType             
        {
            get
            {
                return TheTaxType;
            }
            set
            {
                TheTaxType = value;
            }
        }
        /// <summary>
        /// Number of lines (use with Transaction Type: LOCAL_TYPE and Service Type: LINES)
        /// </summary>
         public int    Lines               
        {
            get
            {
                return TheLines;
            }
            set
            {
                TheLines = value;
            }
        }
        /// <summary>
        /// Minutes of call, set to zero when not appropriate. NOTE: Some taxes are per minute.
        /// </summary>
         public double Minutes             
        {
            get
            {
                return TheMinutes;
            }
            set
            {
                TheMinutes = value;
            }
        }

        /// <summary>
        /// List of optional alphanumeric fields passed in by the client.
        /// </summary>
        
        public List<OptionalField> OptionalFields
        {
            get { return optionalFields; }
            set { optionalFields = value; }
        }
        #endregion

    }
}
