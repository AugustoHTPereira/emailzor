using Emailzor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emailzor.Core.Settings
{
    public class Settings : ISettings
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public string DefaultFromName { get; set; }
        public string DefaultFromAddress { get; set; }

        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
    }
}
