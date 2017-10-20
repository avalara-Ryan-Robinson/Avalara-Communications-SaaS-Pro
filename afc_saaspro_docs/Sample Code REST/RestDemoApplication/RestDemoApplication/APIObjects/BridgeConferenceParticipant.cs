/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    BridgeConferenceParticipant Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Runtime.Serialization;

namespace Avalara.TestCommon.APIObjects
{
    [DataContract]
    public class BridgeConferenceParticipant
    {
        private ZipAddress TheParticipantAddress = new ZipAddress();
        private uint? TheParticipantPCode = null;
        private uint? TheParticipantNpaNxx = null;
        private string TheParticipantRef = string.Empty;

        /// <summary>
        /// Bill to Address
        /// </summary>
        [DataMember]
        public ZipAddress ParticipantAddress
        {
            get
            {
                return TheParticipantAddress;
            }
            set
            {
                TheParticipantAddress = value;
            }
        }
        /// <summary>
        /// Bill to PCode
        /// </summary>
        [DataMember]
        public uint? ParticipantPCode
        {
            get
            {
                return TheParticipantPCode;
            }
            set
            {
                TheParticipantPCode = value;
            }
        }
        /// <summary>
        /// Bill to NpaNxx
        /// </summary>
        [DataMember]
        public uint? ParticipantNpaNxx
        {
            get
            {
                return TheParticipantNpaNxx;
            }
            set
            {
                TheParticipantNpaNxx = value;
            }
        }

        /// <summary>
        /// Participant Id String Value - User Defined
        /// </summary>
        [DataMember]
        public string ParticipantRef
        {
            get
            {
                return TheParticipantRef;
            }
            set
            {
                TheParticipantRef = value;
            }
        }
    }
}
