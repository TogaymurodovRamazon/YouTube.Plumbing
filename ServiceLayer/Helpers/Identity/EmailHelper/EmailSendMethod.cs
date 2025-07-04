using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers.Identity.EmailHelper
{
    public class EmailSendMethod : IEmailSendMethod
    {
        public Task SendPasswordResetLinkWithToken(string passwordResetLink, string token)
        {
            throw new NotImplementedException();
        }
    }
}
