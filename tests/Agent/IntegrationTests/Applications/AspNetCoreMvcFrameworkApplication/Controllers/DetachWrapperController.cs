// Copyright 2020 New Relic, Inc. All rights reserved.
// SPDX-License-Identifier: Apache-2.0


using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcFrameworkApplication.Controllers
{
    public class DetachWrapperController : Controller
    {
        public async Task<string> CallAsyncExternal()
        {
            var task = Task.Run(async () => await AsyncMethodWithExternalCall());

            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("http://www.newrelic.com");
            }

            await task;
            return "Worked";
        }

        private async Task<string> AsyncMethodWithExternalCall()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("http://www.google.com");
                return result;
            }
        }
    }
}
