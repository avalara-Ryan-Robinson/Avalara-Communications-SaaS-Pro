/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    CalcTaxesInCustModeRequest Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Avalara.TestCommon.APIObjects
{
    /// <summary>
    /// Parameter for CustMode/CalcTaxesInCustMode API.
    /// </summary>
    [DataContract]
    public partial class CalcTaxesInCustModeRequest
    {
        /// <summary>
        /// List of transactions to process.
        /// </summary>
        [DataMember(Name="Transactions", EmitDefaultValue=false)]
        public List<Transaction> Transactions { get; set; }

        /// <summary>
        /// List of adjustments to process.
        /// </summary>
        [DataMember(Name="Adjustments", EmitDefaultValue=false)]
        public List<Transaction> Adjustments { get; set; }

        /// <summary>
        /// List of states for tax exclusions.
        /// </summary>
        [DataMember(Name="Exclusions", EmitDefaultValue=false)]
        public List<Exclusion> Exclusions { get; set; }

        /// <summary>
        /// Indicates if the individual transaction taxes should be returned in the response.
        /// </summary>
        [DataMember(Name="ReturnDetail", EmitDefaultValue=false)]
        public bool? ReturnDetail { get; set; }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
