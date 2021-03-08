using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emailzor.Core
{
    public interface IEmailService : IDisposable
    {
        Task SendAsync();

        IEmailService SetDestinatary(string email);
        IEmailService SetSubject(string subject);
        IEmailService SetAttatchments(string[] filesLocation);
        IEmailService SetHtml(string html);

        /// <summary>
        /// Do not use this method when use SetHtml
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        IEmailService SetPlainText(string plainText);
    }
}
