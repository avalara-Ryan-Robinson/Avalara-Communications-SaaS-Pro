/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    AIC3Token Implementation


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System;
using System.Text;

namespace Avalara.TestCommon.Common
{
    public class AIC3Token
    {
        public const string SessionTokenIdentifier = "AvalaraSessionAuth";
        public const string AccessKeyTokenIdentifier = "AvalaraAuth";
        public const string BasicAuthIdentifier = "Basic";

        public string Value { get; set; }
        public string Type { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }

        public static AIC3Token CreateBasicAuthToken(string username, string password)
        {
            return new AIC3Token
            {
                EffectiveFrom = DateTime.MinValue,
                EffectiveTo = DateTime.MaxValue,
                Type = BasicAuthIdentifier,
                Value = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", username, password)))
            };
        }

        public static AIC3Token CreateAvalaraAuthToken(string username, string password)
        {
            return new AIC3Token
            {
                EffectiveFrom = DateTime.MinValue,
                EffectiveTo = DateTime.MaxValue,
                Type = AccessKeyTokenIdentifier,
                Value = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", username, password)))
            };
        }

        public static AIC3Token CreateAvalaraSessionToken(string token)
        {
            return new AIC3Token
            {
                EffectiveFrom = DateTime.MinValue,
                EffectiveTo = DateTime.MaxValue,
                Type = SessionTokenIdentifier,
                Value = token
            };
        }
    }

    public class SessionTokenResponse
    {
        public string actorId { get; set; }
        public string tokenName { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime effectiveTo { get; set; }
        public DateTime effectiveFrom { get; set; }
        public string sessionKeyId { get; set; }
        public string sessionKeyToken { get; set; }
        public string name { get; set; }
        public string contactEmail { get; set; }
    }
}
