using Project.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Project.Models.Services
{
    public static class Mail
    {
        public static void Send(string topic, string firstName, string lastName, string email, string country, string text)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(EMAIL_TO);
            mail.Subject = topic;
            mail.Body = "<p>" + text + "</p>" + "<br/>" +
                "<p>" + firstName + ' ' + lastName + ' ' + email + ' ' + country + "</p>";
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();

            smtp.Send(mail);
        }

        public const string EMAIL_TO = "a.d.a.2013@mail.ru";

    }
}