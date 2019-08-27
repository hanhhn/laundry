using System;
using System.Threading.Tasks;

namespace Cf.Libs.Service.Emails
{
    public class EmailSenderService : IEmailSenderService
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
