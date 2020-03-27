using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_CapStone_Mentorship_Service.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Project_CapStone_Mentorship_Service.Services
{
    public class EmailServices
    {
        private static void Main()
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            var mentorEmail = new Mentor();
            var studentEmails = new Student();
            var forms = new LessonActivity();
            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(mentorEmail.Email, "Mentor Email");
            var subject = forms.Description;
            var to = new EmailAddress(studentEmails.Parent_Email, "Parent Email");
            var plainTextContent = "This is an automated email";
            var htmlContent = "<strong>automated email</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        static async Task Execute2()
        {
            var mentorEmail = new Mentor();
            var studentEmails = new Student();
            var forms = new LessonActivity();
            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(mentorEmail.Email, "Mentor Email");
            var subject = forms.Description;
            var to = new EmailAddress(studentEmails.Instructor_Email, "Parent Email");
            var plainTextContent = "This is an automated email";
            var htmlContent = "<strong>automated email</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
