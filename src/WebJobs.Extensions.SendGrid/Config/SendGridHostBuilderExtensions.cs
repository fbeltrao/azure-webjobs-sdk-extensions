﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Extensions.Bindings;
using Microsoft.Azure.WebJobs.Extensions.Config;
using Microsoft.Azure.WebJobs.Extensions.SendGrid;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// Extension methods for SendGrid integration
    /// </summary>
    public static class SendGridHostBuilderExtensions
    {
        /// <summary>
        /// Adds the SendGrid extension to the provided <see cref="IHostBuilder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IHostBuilder"/> to configure.</param>
        public static IHostBuilder AddSendGrid(this IHostBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<SendGridExtensionConfigProvider>();
            builder.ConfigureServices(s =>
            {
                s.AddSingleton<ISendGridClientFactory, DefaultSendGridClientFactory>();
                s.AddOptions<SendGridOptions>()
                    .Configure<IConfiguration>((options, config) =>
                    {
                        SendGridHelpers.ApplyConfigurationSection(config, options);
                    });
            });

            return builder;
        }

        /// <summary>
        /// Adds the SendGrid extension to the provided <see cref="IHostBuilder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IHostBuilder"/> to configure.</param>
        /// <param name="configure">An <see cref="Action{SendGridOptions}"/> to configure the provided <see cref="SendGridOptions"/>.</param>
        public static IHostBuilder AddSendGrid(this IHostBuilder builder, Action<SendGridOptions> configure)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            builder.AddSendGrid()
                .ConfigureServices(c => c.Configure(configure));

            return builder;
        }
    }
}
