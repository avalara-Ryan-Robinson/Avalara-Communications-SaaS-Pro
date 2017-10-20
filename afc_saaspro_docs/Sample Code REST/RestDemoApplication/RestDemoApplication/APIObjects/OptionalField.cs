/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    OptionalField Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System;

namespace Avalara.TestCommon.APIObjects
{
    /// <summary>
    /// Data structure used to provide optional alphanumeric data for transactions.
    /// </summary>
    [DataContract]
    public class OptionalField
    {
      private static readonly int maxOptionalFields = 2; // int.Parse(Utilities.Configuration["MaxOptionalFields"]);

        #region Data Declarations

        private short optionalKeyNo;
        private string optionalValue;

        #endregion

        #region Public Properties

        /// <summary>
        /// Key number (1 to 10) for optional field.
        /// </summary>
        [DataMember]
        public short OptionalKeyNo
        {
            get { return optionalKeyNo; }
            set { this.optionalKeyNo = value; }
        }

        /// <summary>
        /// Optional field value.
        /// </summary>
        [DataMember]
        public string OptionalValue
        {
            get { return optionalValue; }
            set { this.optionalValue = value; }
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Validates the provided list of optional fields.
        /// </summary>
        /// <param name="optionalFields">OptionalField list.</param>
        /// <returns>true if validation succeeded. An exception is thrown if validation fails.</returns>
        public static bool ValidateOptionalFields(List<OptionalField> optionalFields)
        {
            // Validate optional alphanumeric list
            if (optionalFields != null && optionalFields.Count > 0)
            {
                // Elements in list should not exceed limit specified in config file
                if (optionalFields.Count > maxOptionalFields)
                    throw new Exception("Number of elements in OptionalFields list cannot exceed " + maxOptionalFields + ".");

                if (optionalFields.Any(f => f.OptionalKeyNo < 1 || f.OptionalKeyNo > maxOptionalFields))
                    throw new Exception("OptionalKeyNo in OptionalFields list must be from 1 to " + maxOptionalFields + ".");

                // Ensure client did not enter a key number more than once
                if (optionalFields.GroupBy(f => f.OptionalKeyNo).Any(g => g.Count() > 1))
                    throw new Exception("OptionalKeyNo in OptionalFields list must be unique.");
            }

            return true;
        }

        #endregion
    }
}