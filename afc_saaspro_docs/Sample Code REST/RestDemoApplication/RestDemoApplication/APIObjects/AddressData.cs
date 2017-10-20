/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    AddressData Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/

namespace Avalara.TestCommon.APIObjects
{
    public class AddressData
    {
        public string CountryISO { get; set; }
        public string County { get; set; }
        public string Locality { get; set; }
        public string State { get; set; }
        public int TaxLevel { get; set; }
        public string ZipBegin { get; set; }
        public string ZipEnd { get; set; }
        public string ZipP4Begin { get; set; }
        public string ZipP4End { get; set; }
     
    }
}
