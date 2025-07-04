using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers.Identity.EmailHelper
{
    public interface IEmailSendMethod
    {
        Task SendPasswordResetLinkWithToken(string passwordResetLink, string token);
    }
}
