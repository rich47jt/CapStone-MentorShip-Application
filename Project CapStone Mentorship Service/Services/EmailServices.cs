using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_CapStone_Mentorship_Service.Models;
using Project_CapStone_Mentorship_Service.Views;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Project_CapStone_Mentorship_Service.Services
{
    public class EmailServices
    {
       

        public  async Task Execute()
        {
            var mentorEmail = new Mentor();
            var studentEmails = new Student();
            var forms = new LessonActivity();
            var apiKey = Environment.GetEnvironmentVariable(ApiKeys.SendGridApiKey);
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(mentorEmail.Email, "Mentor Email");
            var subject = forms.Description;
            var to = new EmailAddress(studentEmails.Parent_Email, "Parent Email");
            var plainTextContent = "This is an automated email";
            var htmlContent = "<strong>automated email</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public  async Task Execute_2()
        {
            var mentorEmail = new Mentor();
            var studentEmails = new Student();
            var forms = new LessonActivity();
            var apiKey = Environment.GetEnvironmentVariable(ApiKeys.SendGridApiKey);
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
