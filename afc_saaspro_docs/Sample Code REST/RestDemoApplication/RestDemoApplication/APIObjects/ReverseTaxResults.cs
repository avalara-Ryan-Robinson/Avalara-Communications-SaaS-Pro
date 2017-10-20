/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    TaxInclusive(Reverse)TaxResults Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Collections.Generic;

namespace Avalara.TestCommon.APIObjects
{
    public class ReverseTaxResults
    {
        /// <summary>
        /// Base sale amount necessary to arrive at desired total tax.
        /// </summary>
        public double BaseSaleAmount { get; set; }

        /// <summary>
        /// Taxes generated for the transaction.
        /// </summary>
        public List<TaxData> Taxes { get; set; }
    }
}
