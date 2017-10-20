/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    Sales and Use Attributes Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Runtime.Serialization;

namespace Avalara.TestCommon.APIObjects
{
    public interface ISaleAttributes
    {

    }
    /// <summary>
    /// <summary>
    /// Default Attributes
    /// </summary>
    [DataContract]
    public class DefaultAttributes : ISaleAttributes
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DefaultAttributes()
        {

        }
        #endregion

    }

    /// <summary>
    /// Demurrage Attributes
    /// </summary>
    [DataContract]
    public class DemurrageAttributes : ISaleAttributes
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DemurrageAttributes()
        {

        }
        #endregion

    }

    /// <summary>
    /// Trade In Attributes
    /// </summary>
    [DataContract]
    public class TradeInAttributes : ISaleAttributes
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public TradeInAttributes()
        {

        }
        #endregion
    }

    /// <summary>
    /// Deposit Attributes
    /// </summary>
    [DataContract]
    public class DepositAttributes : ISaleAttributes
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DepositAttributes()
        {

        }
        #endregion
    }
    /// <summary>
    /// Freight Attributes
    /// </summary>
    [DataContract]
    public class FreightAttributes : ISaleAttributes
    {
        #region Data Declarations
        private bool _paidToSeller = false;
        private bool _commonCarrier = false;
        private bool _sellerReqShipping = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FreightAttributes()
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Paid to Seller
        /// </summary>
        [DataMember]
        public bool PaidToSeller
        {
            get
            {
                return _paidToSeller;
            }
            set
            {
                _paidToSeller = value;
            }
        }
        /// <summary>
        /// Common Carrier
        /// </summary>
        [DataMember]
        public bool CommonCarrier
        {
            get
            {
                return _commonCarrier;
            }
            set
            {
                _commonCarrier = value;
            }
        }
        /// <summary>
        /// Seller Req Shipping
        /// </summary>
        [DataMember]
        public bool SellerReqShipping
        {
            get
            {
                return _sellerReqShipping;
            }
            set
            {
                _sellerReqShipping = value;
            }
        }
        #endregion
    }

    /// <summary>
    /// Discount Attributes
    /// </summary>
    [DataContract]
    public class DiscountAttributes : ISaleAttributes
    {
        #region Data Declarations
        private int _discountType = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DiscountAttributes()
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Discount Type
        /// </summary>
        [DataMember]
        public int DiscountType
        {
            get
            {
                return _discountType;
            }
            set
            {
                _discountType = value;
            }
        }
        #endregion
    }

    /// <summary>
    /// Finance Attributes
    /// </summary>
    [DataContract]
    public class FinanceAttributes : ISaleAttributes
    {
        #region Data Declarations
        private int _financeType = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FinanceAttributes()
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Finance Type
        /// </summary>
        [DataMember]
        public int FinanceType
        {
            get
            {
                return _financeType;
            }
            set
            {
                _financeType = value;
            }
        }
        #endregion
    }

    /// <summary>
    /// Installation Attributes
    /// </summary>
    [DataContract]
    public class InstallationAttributes : ISaleAttributes
    {
        #region Data Declarations
        private int _installationType = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public InstallationAttributes()
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Installation Type
        /// </summary>
        [DataMember]
        public int InstallationType
        {
            get
            {
                return _installationType;
            }
            set
            {
                _installationType = value;
            }
        }
        #endregion
    }

    /// <summary>
    /// Ship and Handling Attributes
    /// </summary>
    [DataContract]
    public class ShipAndHandlingAttributes : ISaleAttributes
    {
        #region Data Declarations
        private bool _sellerReqShipping = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ShipAndHandlingAttributes()
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Seller Req Shipping
        /// </summary>
        [DataMember]
        public bool SellerReqShipping
        {
            get
            {
                return _sellerReqShipping;
            }
            set
            {
                _sellerReqShipping = value;
            }
        }
        #endregion
    }

    /// <summary>
    /// Software Maint Attributes
    /// </summary>
    [DataContract]
    public class SoftwareMaintAttributes : ISaleAttributes
    {
        #region Data Declarations
        private bool _sellerRequired = false;
        private int _agreementType = 0;
        private int _updateType = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SoftwareMaintAttributes()
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Seller Required
        /// </summary>
        [DataMember]
        public bool SellerRequired
        {
            get
            {
                return _sellerRequired;
            }
            set
            {
                _sellerRequired = value;
            }
        }
        /// <summary>
        /// Agreement Type
        /// </summary>
        [DataMember]
        public int AgreementType
        {
            get
            {
                return _agreementType;
            }
            set
            {
                _agreementType = value;
            }
        }
        /// <summary>
        /// Update Type
        /// </summary>
        [DataMember]
        public int UpdateType
        {
            get
            {
                return _updateType;
            }
            set
            {
                _updateType = value;
            }
        }
        #endregion
    }
    /// <summary>
    /// Service Contract Attributes
    /// </summary>
    [DataContract]
    public class ServiceContractAttributes : ISaleAttributes
    {
        #region Data Declarations
        private bool _sellerRequired = false;
        private int _agreementType = 0;
        private int _timeOfSale = 0;
        private int _itemType = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceContractAttributes()
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Seller Required
        /// </summary>
        [DataMember]
        public bool SellerRequired
        {
            get
            {
                return _sellerRequired;
            }
            set
            {
                _sellerRequired = value;
            }
        }

        /// <summary>
        /// Agreement Type
        /// </summary>
        [DataMember]
        public int AgreementType
        {
            get
            {
                return _agreementType;
            }
            set
            {
                _agreementType = value;
            }
        }
        /// <summary>
        /// Time of Sale
        /// </summary>
        [DataMember]
        public int TimeOfSale
        {
            get
            {
                return _timeOfSale;
            }
            set
            {
                _timeOfSale = value;
            }
        }
        /// <summary>
        /// Item Type
        /// </summary>
        [DataMember]
        public int ItemType
        {
            get
            {
                return _itemType;
            }
            set
            {
                _itemType = value;
            }
        }
        #endregion
    }
    /// <summary>
    /// Maint Agreement Attributes
    /// </summary>
    [DataContract]
    public class MaintAgreementAttributes : ISaleAttributes
    {
        #region Data Declarations
        private bool _sellerRequired = false;
        private int _agreementType = 0;
        private int _timeOfSale = 0;
        private int _itemType = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MaintAgreementAttributes()
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Seller Required
        /// </summary>
        [DataMember]
        public bool SellerRequired
        {
            get
            {
                return _sellerRequired;
            }
            set
            {
                _sellerRequired = value;
            }
        }
        /// <summary>
        /// Agreement Type
        /// </summary>
        [DataMember]
        public int AgreementType
        {
            get
            {
                return _agreementType;
            }
            set
            {
                _agreementType = value;
            }
        }
        /// <summary>
        /// Time of Sale
        /// </summary>
        [DataMember]
        public int TimeOfSale
        {
            get
            {
                return _timeOfSale;
            }
            set
            {
                _timeOfSale = value;
            }
        }
        /// <summary>
        /// Item Type
        /// </summary>
        [DataMember]
        public int ItemType
        {
            get
            {
                return _itemType;
            }
            set
            {
                _itemType = value;
            }
        }
        #endregion
    }

    /// <summary>
    /// Factory Warranty Attributes
    /// </summary>
    [DataContract]
    public class FactoryWarrantyAttributes : ISaleAttributes
    {
        #region Data Declarations
        private bool _sellerRequired = false;
        private int _agreementType = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FactoryWarrantyAttributes()
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Seller Required
        /// </summary>
        [DataMember]
        public bool SellerRequired
        {
            get
            {
                return _sellerRequired;
            }
            set
            {
                _sellerRequired = value;
            }
        }
        /// <summary>
        /// Agreement Type
        /// </summary>
        [DataMember]
        public int AgreementType
        {
            get
            {
                return _agreementType;
            }
            set
            {
                _agreementType = value;
            }
        }
        #endregion
    }
    /// <summary>
    /// Ext Warranty Attributes
    /// </summary>
    [DataContract]
    public class ExtWarrantyAttributes : ISaleAttributes
    {
        #region Data Declarations
        private bool _sellerRequired = false;
        private int _agreementType = 0;
        private int _timeOfSale = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ExtWarrantyAttributes()
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Seller Required
        /// </summary>
        [DataMember]
        public bool SellerRequired
        {
            get
            {
                return _sellerRequired;
            }
            set
            {
                _sellerRequired = value;
            }
        }
        /// <summary>
        /// Agreement Type
        /// </summary>
        [DataMember]
        public int AgreementType
        {
            get
            {
                return _agreementType;
            }
            set
            {
                _agreementType = value;
            }
        }
        /// <summary>
        /// Time of Sale
        /// </summary>
        [DataMember]
        public int TimeOfSale
        {
            get
            {
                return _timeOfSale;
            }
            set
            {
                _timeOfSale = value;
            }
        }
        #endregion
    }
}
