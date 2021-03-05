using System;

namespace Emailzor.Core
{
    public class EmailMessage
    {
        public string DisplayName { get; set; }
        public string To { get; set; }
        public string[] Copies { get; set; }

        public string Subject { get; set; }
        public string Html { get; set; }
        public string PlainText { get; set; }
        public object[] Attatchments { get; set; }

        public string ErrorMessage { get; set; }
        public bool Error
        {
            get { return string.IsNullOrEmpty(ErrorMessage); }
        }
    }
}
