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
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Avalara.TestCommon.APIObjects
{
    /// <summary>
    /// Jurisdiction information returned when searching location matches.
    /// </summary>
    [DataContract]
    public class ZipLookupResult
    {
        /// <summary>
        /// List of location matches for the address being searched.
        /// </summary>
        [DataMember]
        public List<LocationItem> LocationData { get; set; }

        /// <summary>
        /// Indicates whether the matches returned are based on an "Exact" match or "Best" match.
        /// </summary>
        [DataMember]
        public string MatchType { get; set; }
    }
}
