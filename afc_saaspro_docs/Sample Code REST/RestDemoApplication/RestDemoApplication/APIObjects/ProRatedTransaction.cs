/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    ProRatedTransaction Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Runtime.Serialization;

namespace Avalara.TestCommon.APIObjects
{
    [DataContract]
    public class ProRatedTransaction
    {
        /// <summary>
        /// Percentage to prorate.
        /// </summary>
        [DataMember]
        public double ProRatedPercent { get; set; }

        /// <summary>
        /// Telecom data.
        /// </summary>
        [DataMember]
        public Transaction Transaction { get; set; }
    }
}
