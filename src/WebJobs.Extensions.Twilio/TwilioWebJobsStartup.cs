﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Extensions.Twilio;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Hosting;

[assembly: WebJobsStartup(typeof(TwilioWebJobsStartup))]

namespace Microsoft.Azure.WebJobs.Extensions.Twilio
{
    public class TwilioWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IHostBuilder builder)
        {
            builder.AddTwilioSms();
        }
    }
}
