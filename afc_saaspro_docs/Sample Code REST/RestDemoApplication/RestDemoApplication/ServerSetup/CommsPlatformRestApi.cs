/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    Communications platform rest client implementation 


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Avalara.TestCommon.Common;
using Newtonsoft.Json;
using System.Text;
using System.Configuration;

namespace Avalara.TestCommon.ServerSetup
{
    public class CommsPlatformRestApi : HttpClient
    {
        public static string ClientUserName = string.Empty;
        public static string ClientPassword = string.Empty;
        public static string ClientId = string.Empty;
        public static string ClientProfileId = string.Empty;

        public CommsPlatformRestApi()
        {
            if (string.IsNullOrEmpty(ClientUserName)) ClientUserName = ConfigurationManager.AppSettings["DefaultUsername"];
            if (string.IsNullOrEmpty(ClientPassword)) ClientPassword = ConfigurationManager.AppSettings["DefaultPassword"];
            if (string.IsNullOrEmpty(ClientId)) ClientId = ConfigurationManager.AppSettings["ClientId"];
            if (string.IsNullOrEmpty(ClientProfileId)) ClientProfileId = ConfigurationManager.AppSettings["ClientProfileId"];

            BaseAddress = new Uri(ConfigurationManager.AppSettings["DefaultUrl"]);
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", AIC3Token.CreateBasicAuthToken(ClientUserName, ClientPassword).Value);
            DefaultRequestHeaders.Add("client_id", ClientId);
            DefaultRequestHeaders.Add("client_profile_id", ClientProfileId);

        }

        public static void SetUserCredentials(string uname, string pword)
        {
            ClientUserName = uname;
            ClientPassword = pword;
        }

        public static void SetUserCredentials(string uname, string pword, int clientId, int clientProfileId)
        {
            ClientUserName = uname;
            ClientPassword = pword;
            ClientId = clientId.ToString();
            ClientProfileId = clientProfileId.ToString();
        }

        public Task<HttpResponseMessage> PostAsJson(string requestUri, object data)
        {
            var objectString = JsonConvert.SerializeObject(data);
            return this.PostAsync(requestUri, new StringContent(objectString, Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> PostAsJsonAsync(string requestUri, object data)
        {
            var objectString = JsonConvert.SerializeObject(data);
            return await this.PostAsync(requestUri, new StringContent(objectString, Encoding.UTF8, "application/json"));
        }
    }
}
