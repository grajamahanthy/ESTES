using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLib.Common.Classes
{
    public class SmtpModel
    {
        public int Port { get; set; }
        public string Host { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Message message { get; set; }
    }

    public class Message
    {
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string EmailSubject { get; set; }
        public bool IsBodyHtml { get; set; }
        public string EmailBody { get; set; }
    }
}
