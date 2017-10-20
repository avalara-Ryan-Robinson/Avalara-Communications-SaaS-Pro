/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    Nexus Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Runtime.Serialization;

namespace Avalara.TestCommon.APIObjects
{
    /// <summary>
    /// Nexus Class
    /// </summary>
    [DataContract]
    public class Nexus
    {
        #region Data Declarations
        private string _state = "";
        private bool _hasNexus = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Nexus()
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Two-character abbreviation for State
        /// </summary>
        [DataMember]
        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }
        /// <summary>
        /// True if entity has Nexus in the state, otherwise False
        /// </summary>
        [DataMember]
        public bool HasNexus
        {
            get
            {
                return _hasNexus;
            }
            set
            {
                _hasNexus = value;
            }
        }
        #endregion
    }
}
