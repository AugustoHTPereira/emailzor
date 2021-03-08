using Emailzor.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emailzor.Core
{
    public static class Bootstrapper
    {
        public static void AddEmailzor(this IServiceCollection services, ISettings settings)
        {
            services.AddSingleton(settings);
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
