using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcossieBank_IT1.Controllers
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";


        public void Send(String toEmail, String subject, String contents)
        {
            //system get message from user
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress(toEmail, "Email from User");
            var to = new EmailAddress("ecossiekids@gmail.com", "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);

            // user recevie mmessage from system
            var client2 = new SendGridClient(API_KEY);
            var from2 = new EmailAddress("noreply@localhost.com", "Email from Eco");
            var to2 = new EmailAddress(toEmail, "");
            var plainTextContent2 = "Thanks for your advice, we will contact you soon.";
            var htmlContent2 = "<p>" +
                "Hi, " + subject + "!" + "<br></br>" + "<br></br>"
                + "Thank you so much for reaching out! This is auto-reply is just to let you know..." + "<br></br>" + "<br></br>"
                + "We received your email and will get back to you with a (human) response as soon as possible. During 8am to 6pm that's "
                + "usually within a couple of hours. Evenings and weekends may take us a little bit longer." + "<br></br>" + "<br></br>"
                + "If you have any additional questions that you think will help us to assist you, please feel free to reply this email. " + "<br></br>"
                + "We look forward to chatting soon!" + "<br></br>" + "<br></br>"
                + "Cheers," + "<br></br>" + "</br>"
                + "Lin"
                + "</p>";
            var msg2 = MailHelper.CreateSingleEmail(from2, to2, "We got it", plainTextContent2, htmlContent2);
            var response2 = client2.SendEmailAsync(msg2);
        }

    }
}