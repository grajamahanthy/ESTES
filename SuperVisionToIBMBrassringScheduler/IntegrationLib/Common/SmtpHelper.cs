using IntegrationLib.Common.Classes;
using IntegrationLib.IntegrationHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace IntegrationLib.Common
{
    public class SmtpHelper : SmtpModel
    {
        //Our single instance of the singleton
        private static SmtpHelper instance = null;

        //Private constructor to deny instance creation of this class from outside
        private SmtpHelper()
        {
        }



        //GetInstace method to be used to create or reach the single resource (instance)
        public static SmtpHelper GetInstance(Config config)
        {
            try
            {
                if (instance == null)
                {
                    instance = new SmtpHelper();
                    //instance.Port = config.Smtp.Port;
                    instance.Host = config.Smtp.Host;
                    instance.EnableSsl = config.Smtp.EnableSsl;
                    instance.UseDefaultCredentials = config.Smtp.UseDefaultCredentials;
                    if (instance.UseDefaultCredentials)
                    {
                        instance.UserName = config.Smtp.UserName;
                        instance.Password = config.Smtp.Password;
                    }
                    instance.message = new Message()
                    {
                        FromEmail = config.Smtp.Mail.From,
                        ToEmail = config.Smtp.Mail.To,
                        EmailSubject = config.Smtp.Mail.Subject,
                        IsBodyHtml = (config.Smtp.Mail.IsHtml == 1), //to make message body as html  
                        EmailBody = config.Smtp.Mail.Body
                    };
                }
                return instance;
            }
            catch (Exception ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
                throw ex;
            }
        }



        //Implement functionality as public instance methods
        public void SendEmail(List<string> attachmentPaths)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                mail.From = new MailAddress(instance.message.FromEmail);
                foreach (string toEmail in instance.message.ToEmail.Split(','))
                {
                    mail.To.Add(new MailAddress(toEmail));
                }
                mail.Subject = instance.message.EmailSubject;
                mail.IsBodyHtml = instance.message.IsBodyHtml; //to make message body as html  
                mail.Body = instance.message.EmailBody.Replace("<", "&lt;").Replace(">", "&gt;");
                //smtp.Port = instance.Port;
                smtp.Host = instance.Host; //for gmail host  
                smtp.EnableSsl = instance.EnableSsl;
                smtp.UseDefaultCredentials = instance.UseDefaultCredentials;

                if (instance.UseDefaultCredentials)
                    smtp.Credentials = new NetworkCredential(instance.UserName, instance.Password);

                if (attachmentPaths.Count > 0)
                {
                    foreach (string filePath in attachmentPaths)
                    {
                        Attachment attachment = new System.Net.Mail.Attachment(filePath);
                        mail.Attachments.Add(attachment);
                    }
                }

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
            }
            finally
            {
                mail.Dispose();
                smtp.Dispose();
            }
        }
    }
}
