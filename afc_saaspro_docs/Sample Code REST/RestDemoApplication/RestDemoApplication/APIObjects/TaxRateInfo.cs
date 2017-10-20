/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    TaxRateInfo Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Collections.Generic;

namespace Avalara.TestCommon.APIObjects
{
    public class TaxRateInfo
    {
        public short TaxType { get; set; }
        public short TaxLevel { get; set; }
        public List<TaxRateHistory> RateHistory { get; set; }
    }
}
