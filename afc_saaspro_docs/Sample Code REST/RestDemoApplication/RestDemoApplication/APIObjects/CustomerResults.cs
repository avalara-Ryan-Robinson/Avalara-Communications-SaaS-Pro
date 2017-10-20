/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    CustomerResults Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Collections.Generic;

namespace Avalara.TestCommon.APIObjects
{
    public class CustomerResults
    {
        private List<TaxData> taxes = new List<TaxData>();
        private List<CustomerTaxData> custTaxes = new List<CustomerTaxData>();

        /// <summary>
        /// Individual taxes for each transaction.
        /// </summary>
        public List<TaxData> Taxes
        {
            get { return taxes; }
            set { taxes = value; }
        }

        /// <summary>
        /// Summarized taxes for customer batch.
        /// </summary>
        public List<CustomerTaxData> SummarizedTaxes
        {
            get { return custTaxes; }
            set { custTaxes = value; }
        }
    }
}
