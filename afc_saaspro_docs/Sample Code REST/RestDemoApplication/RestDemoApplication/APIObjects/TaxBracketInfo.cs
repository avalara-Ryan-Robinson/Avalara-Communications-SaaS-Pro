/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    TaxBracketInfo Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/

namespace Avalara.TestCommon.APIObjects
{
    public class TaxBracketInfo
    {
        public double Rate { get; set; }
        public double MaxBase { get; set; }
        public double CountyOverrideTax { get; set; }
        public double StateOverrideTax { get; set; }
        public bool StateOverrideOn { get; set; }
        public bool CountyOverrideOn { get; set; }
    }
}
