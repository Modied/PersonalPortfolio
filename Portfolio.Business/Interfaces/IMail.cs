using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface IMail
    {
        Task SendEmailAsync(MailVModel mailVModel);
    }
}
