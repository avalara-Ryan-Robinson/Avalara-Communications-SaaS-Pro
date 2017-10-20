/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    EnumeratedTypes for Rest Demo Application


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/

namespace Avalara.TestCommon.Common
{
   public class EnumeratedTypes
   {
      /// <summary>
      /// Test Calculation Type
      /// </summary>
      public enum TestCalculationTypes
      {
         StdTaxes,               //
         StdAdjustments,         //
         TaxInclusive,           //
         TaxInclusiveAdjustment, //
         ZipLookup,              //
         EndOfTestCalculationTypes
      }

      /// <summary>
      /// Jurisdiction Type
      /// </summary>
      public enum JType : int
      {
         None = 0,
         JCode = 1,
         PCode = 2,
         FipsCode = 3,
         ZipAddress = 4,
         NpaNxx = 5,
         Mixed = 6
      }

   }
}
