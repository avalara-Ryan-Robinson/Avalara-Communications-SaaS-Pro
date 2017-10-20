/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    Exclusion Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Runtime.Serialization;

namespace Avalara.TestCommon.APIObjects
{
    [DataContract]
    public class Exclusion
    {
        #region Data Declarations
        private string TheCountryISO  = "";
        private string TheState       = "";
        private bool   TheExclusionOn = false;
        #endregion

        #region Constructor
        public Exclusion () 
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// CountryISO
        /// </summary>
        [DataMember] public string CountryISO  
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
        [DataMember] public string State       
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
        /// True if entity Exclusion applies in the state, otherwise False
        /// </summary>
        [DataMember] public bool   ExclusionOn 
        {
            get
            {
                return TheExclusionOn;
            }
            set
            {
                TheExclusionOn = value;
            }
        }
        #endregion
    }
}
