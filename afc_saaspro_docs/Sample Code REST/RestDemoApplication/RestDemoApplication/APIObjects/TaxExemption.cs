/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    TaxExemption Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Runtime.Serialization;


namespace Avalara.TestCommon.APIObjects
{
    [DataContract]
    public class TaxExemption        
    {
        #region Data Declarations
        private uint  ThePCode    = 0;
        private int   TheTaxLevel = 0;
        private short TheTaxType  = 0;
        #endregion

        #region Constructor
        public TaxExemption () 
        {

        }
        #endregion
              

        #region Public Properties
        /// <summary>
        /// Jurisdiction Code for Tax Exemption
        /// </summary>
        [DataMember] public uint  PCode    
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
        /// See the EZTaxWebservice User's Manual for valid Tax Levels
        /// </summary>
        [DataMember] public int   TaxLevel 
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
        [DataMember] public short TaxType  
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
        #endregion
    }
}
