/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    AddressToPCodeRequest Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Runtime.Serialization;

namespace Avalara.TestCommon.APIObjects
{
    /// <summary>
    /// Location data used as input for searching jurisdiction matches.
    /// </summary>
    [DataContract]
    public class AddressToPCodeRequest
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
        public string City { get; set; }

        /// <summary>
        /// 5-digit zip code (full zip code for Canadian addresses).
        /// </summary>
        [DataMember]
        public string ZipCode { get; set; }

        /// <summary>
        /// Flag indicating whether to return the best matches (true) or exact matches only (false).
        /// </summary>
        [DataMember]
        public bool BestMatch { get; set; }

        /// <summary>
        /// Indicates if the full jurisdiction details (country ISO, state, county, and city) should be returned in the
        /// results. Otherwise, only the PCode will be included in the response.
        /// </summary>
        [DataMember]
        public bool JurisdictionDetails { get; set; }

        /// <summary>
        /// Maximum number of results to return.
        /// </summary>
        [DataMember]
        public int? LimitResults { get; set; }
    }
}
