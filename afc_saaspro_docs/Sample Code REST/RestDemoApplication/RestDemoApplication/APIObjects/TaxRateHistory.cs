/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    TaxRateHistory Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System;
using System.Collections.Generic;

namespace Avalara.TestCommon.APIObjects
{
    public class TaxRateHistory
    {
        public DateTime EffectiveDate { get; set; }

        public bool LevelExemptible { get; set; }

        public List<TaxBracketInfo> BracketInfo { get; set; }
    }
}
