/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    ZipAddress Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/

namespace Avalara.TestCommon.APIObjects
{
    public class ZipAddress          
    {
        #region Data Declarations
        private string TheCountryISO = "";
        private string TheCounty     = "";
        private string TheLocality   = "";
        private string TheState      = "";
        private string TheZipCode    = "";
        private string TheZipP4      = "";
        #endregion

        #region Constructor
        public ZipAddress ()                                
        {

        }
        public ZipAddress(string countryISO, string state, string county, string locality, string zipCode, string zipP4)
        {
           TheCountryISO = countryISO;
           TheState = state;
           TheCounty = county;
           TheLocality = locality;
           TheZipCode = zipCode;
           TheZipP4 = zipP4;
        }
       
        #endregion

        #region Public Utils

        /// <summary>
        /// Parse input ZipCode
        /// </summary>
        /// <param name="zipCode"></param>
        /// <param name="zipPlus4"></param>
        /// <param name="zipCodeOut"></param>
        /// <param name="zipPlus4Out"></param>
        public static void ParseZipCode(string zipCode, string zipPlus4, out string zipCodeOut, out string zipPlus4Out)
        {
            zipCodeOut = zipCode;
            zipPlus4Out = zipPlus4;

            switch (zipCode.Length)
            {
                case 6: // zipcode input like H0H0H0
                    if (System.Char.IsLetter(zipCode[0]))
                    {
                        zipCodeOut = zipCode.Substring(0, 3);
                        zipPlus4Out = zipCode.Substring(3, 3);
                    }
                    break;
                case 7: // zipcode input like H0H-0H0
                    if (System.Char.IsLetter(zipCode[0]))
                    {
                        zipCodeOut = zipCode.Substring(0, 3);
                        zipPlus4Out = zipCode.Substring(4, 3);
                    }
                    break;
                case 9: // zipcode input like 123451234
                    zipCodeOut = zipCode.Substring(0, 5);
                    zipPlus4Out = zipCode.Substring(5, 4);
                    break;
                case 10:// zipcode input like 12345-1234
                    zipCodeOut = zipCode.Substring(0, 5);
                    zipPlus4Out = zipCode.Substring(6, 4);
                    break;
            }
        }

        #endregion
        #region Public Properties
        /// <summary>
        /// Country ISO code.
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
        /// County name.
        /// </summary>
        public string County     
        {
            get
            {
                return TheCounty;
            }
            set
            {
                TheCounty = value;
            }
        }
        /// <summary>
        /// Locality name.
        /// </summary>
        public string Locality   
        {
            get
            {
                return TheLocality;
            }
            set
            {
                TheLocality = value;
            }
        }
        /// <summary>
        /// Two-character state abbreviation.
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
        /// Zip code for taxing jurisdiction.
        /// </summary>
        public string ZipCode    
        {
            get
            {
                return TheZipCode;
            }
            set
            {
                TheZipCode = value;
            }
        }
        /// <summary>
        /// Zip + 4 for taxing jurisdiction.
        /// </summary>
        public string ZipP4      
        {
            get
            {
                return TheZipP4;
            }
            set
            {
                TheZipP4 = value;
            }
        }
        #endregion
    }
}
