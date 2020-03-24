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
        //private static void Main()
        //{
        //    Execute().Wait();
        //}
        
        static async Task Execute(Student student, Mentor mentor)
        {
            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(mentor.Email, "Mentor");
            var subject = "Lesson Overview";
            var to = new EmailAddress(student.ParentEmail, "Parent");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
        static async Task Execute2(Student student, Mentor mentor)
        {
            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(mentor.Email, "Mentor");
            var subject = "Lesson Overview";
            var to = new EmailAddress(student.InstructorEmail, "Teacher");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }


    }
}
