/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    TaxRateOverrideInfo Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace Avalara.TestCommon.APIObjects
{
    /// <summary>
    /// Tax Rate Override Info Class
    /// </summary>
    [DataContract]
    public class TaxRateOverrideInfo
    {
        /// <summary>
        /// Jurisdiction P Code for this tax rate override
        /// </summary>
        [DataMember(IsRequired = true)]
        public uint Pcode { get; set; }

        /// <summary>
        /// The override scope
        /// </summary>
        [DataMember(IsRequired = true)]
        public short Scope { get; set; }

        /// <summary>
        /// TaxType and TaxLevel is the primary key for TaxRateOverrideInfo
        /// Therefore they are required field
        /// </summary>
        [DataMember(IsRequired = true)]
        public short TaxType { get; set; }

        /// <summary>
        /// TaxLevel is part of the primary key for TaxRateOverrideInfo
        /// Therefore it is required field
        /// </summary>
        [DataMember(IsRequired = true)]
        public short TaxLevel { get; set; }

        /// <summary>
        /// Overwrite the value in eztax database
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool LevelExemptible { get; set; }

        /// <summary>
        /// Overwrite the brackets in eztax database
        /// </summary>
        [DataMember(IsRequired = true)]
        public Collection<TaxBracketInfo> BracketInfo { get; set; }
    }
}
