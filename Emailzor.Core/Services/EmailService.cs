﻿using Emailzor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Emailzor.Core
{
    public class EmailService : IEmailService
    {
        private readonly ISettings Settings;
        private EmailMessage EmailMessage;
        private SmtpClient Client;

        public EmailService(ISettings settings)
        {
            Settings = settings;
            EmailMessage = new EmailMessage();
            Client = new SmtpClient(Settings.Host, Settings.Port)
            {
                Credentials = new NetworkCredential(Settings.SmtpUser, Settings.SmtpPass),
                EnableSsl = true
            };
        }

        public Task SendAsync()
        {
            var mailMessage = new MailMessage(Settings.DefaultFromAddress, EmailMessage.To, EmailMessage.Subject, EmailMessage.Html ?? EmailMessage.PlainText);
            mailMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(EmailMessage.Html, new System.Net.Mime.ContentType("text/html")));
            mailMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(EmailMessage.PlainText, new System.Net.Mime.ContentType("text/plain")));
            mailMessage.From = new MailAddress(Settings.DefaultFromAddress, EmailMessage.DisplayName ?? Settings.DefaultFromName);

            Client.Send(mailMessage);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEmailService SetDestinatary(string email)
        {
            EmailMessage.To = email;

            return this;
        }

        public IEmailService SetSubject(string subject)
        {
            EmailMessage.Subject = subject;

            return this;
        }

        public IEmailService SetAttatchments(string[] filesLocation)
        {
            EmailMessage.Attatchments = filesLocation;

            return this;
        }

        public IEmailService SetHtml(string html)
        {
            EmailMessage.Html = html;
            EmailMessage.PlainText = Regex.Replace(html, "<[^>]*>", "");

            return this;
        }

        public IEmailService SetPlainText(string plainText)
        {
            EmailMessage.Html = string.Empty;
            EmailMessage.PlainText = plainText;
            return this;
        }
    }
}
