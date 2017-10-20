/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    Address/Location Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Runtime.Serialization;

namespace Avalara.TestCommon.APIObjects
{
    /// <summary>
    /// Contains name and jurisdiction PCode information for a location.
    /// </summary>
    [DataContract]
    public class LocationItem
    {
        /// <summary>
        /// 3-character country ISO code.
        /// </summary>
        [DataMember]
        public string CountryIso { get; set; }

        /// <summary>
        /// 2-character state abbreviation.
        /// </summary>
        [DataMember]
        public string State { get; set; }

        /// <summary>
        /// County name.
        /// </summary>
        [DataMember]
        public string County { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        [DataMember]
        public string Locality { get; set; }

        /// <summary>
        /// Jurisdiction PCode.
        /// </summary>
        [DataMember]
        public uint PCode { get; set; }
    }
}
