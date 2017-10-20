/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    RequestPCodeDetail Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/

namespace Avalara.TestCommon.APIObjects
{
    public class RequestPCodeDetail
    {
        /// <summary>
        /// Fips code - leave null if other value is used
        /// </summary>
        public string FipsCode { get; set; }

        /// <summary>
        /// NPANXX - leave null if other value is used
        /// </summary>
        public uint? NpaNxx { get; set; }

        /// <summary>
        /// Zip Address - leave null if other value is used
        /// </summary>
        public ZipAddress ZipAddress { get; set; }
    }
}
