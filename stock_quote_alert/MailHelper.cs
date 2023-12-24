using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace inoa_test
{
    class MailHelper
    {
        private SmtpClient smtpClient;

        private string sender;

        private List<string> destinyMails;

        public MailHelper(string host, int port, string userName, string password, List<string> destinyMails)
        {

            this.sender = userName;

            this.destinyMails = destinyMails;

            smtpClient = new SmtpClient(host)
            {
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = port,
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = true
            };

        }

        public void SendMail(string subject, string message)
        {

            var tries = 0;

            var mailMessage = new MailMessage()
            {
                From = new MailAddress(this.sender),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            destinyMails.ForEach(d => mailMessage.To.Add(d));

            while (true || tries > 3)
            {
                try
                {
                    smtpClient.Send(mailMessage);
                    return;
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(Constants.ConsoleMessages.retryMail);
                }
            }

            Console.WriteLine(Constants.ConsoleMessages.exceededRetries);
        }
    }
}
