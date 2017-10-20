/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    BridgeConferenceParticipantResult Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Collections.Generic;

namespace Avalara.TestCommon.APIObjects
{
    public class BridgeConferenceParticipantResult
    {
        /// <summary>
        /// Participant Ref
        /// </summary>
        public string ParticipantRef { get; set; }
        /// <summary>
        /// Error Code
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// Transaction Type
        /// </summary>
        public short TransactionType { get; set; }
        /// <summary>
        /// Service Type
        /// </summary>
        public short ServiceType { get; set; }
        /// <summary>
        /// Participant Taxes
        /// </summary>
        public List<TaxData> ParticipantTaxes { get; set; }
    }
}
