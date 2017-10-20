/**************************************************************************
 **                                                                       *
 ** Copyright 2016 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    CategoryExemption Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/

namespace Avalara.TestCommon.APIObjects
{
    public class CategoryExemption
    {
        #region Data Declarations
        private string TheCountryISO  = "";
        private string TheState       = "";
        private short TheCategoryType = 0;
        #endregion

        #region Constructor
        public CategoryExemption() 
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// CountryISO
        /// </summary>
         public string CountryISO  
        {
            get
            {
                return TheCountryISO;
            }
            set
            {
                TheCountryISO = value;
            }
        }
        /// <summary>
        /// Two-character abbreviation for State
        /// </summary>
         public string State       
        {
            get
            {
                return TheState;
            }
            set
            {
                TheState = value;
            }
        }
        /// <summary>
        /// See the CommsPlatform.API.WrapperClasses User's Manual for valid Tax Categories
        /// </summary>
        
        public short TaxCategory
        {
            get
            {
                return TheCategoryType;
            }
            set
            {
                TheCategoryType = value;
            }
        }
        #endregion
    }
}
