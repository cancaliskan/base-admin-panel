using System;
using MimeKit;

using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.DataAccess.Helpers;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace BaseAdminTemplate.Business.Services
{
    public sealed class EmailService : IEmailService
    {
        public void Send(string to, string subject, string html)
        {
            var host = ConfigurationParameterHelper.GetConfigurationParameter("Host");
            var port = Convert.ToInt32(ConfigurationParameterHelper.GetConfigurationParameter("Port"));
            var senderEmail = ConfigurationParameterHelper.GetConfigurationParameter("SenderEmail");
            var senderEmailPassword = ConfigurationParameterHelper.GetConfigurationParameter("SenderEmailPassword");
            
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("", senderEmail));
            emailMessage.To.Add(new MailboxAddress("", to));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("html") { Text = html };

            using var client = new SmtpClient();
            client.Connect(host, port, false);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate(senderEmail, senderEmailPassword);
            client.Send(emailMessage);
            client.Disconnect(true);
        }
    }
}