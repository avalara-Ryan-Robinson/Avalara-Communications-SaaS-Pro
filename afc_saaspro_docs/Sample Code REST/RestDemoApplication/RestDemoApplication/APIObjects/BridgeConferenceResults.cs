/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    BridgeConferenceResults Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Avalara.TestCommon.APIObjects
{
    [DataContract]
    public class BridgeConferenceResults
    {
        /// <summary>
        /// Participant Taxes
        /// </summary>
        [DataMember]
        public List<BridgeConferenceParticipantResult> ParticipantResults { get; set; }

        /// <summary>
        /// Summarized Taxes for Bridge Conference
        /// </summary>
        [DataMember]
        public List<TaxData> Taxes { get; set; }
    }
}
