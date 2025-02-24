using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.ViewModels
{
    public class MailVModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Subject { get; set; }

        public string Body { get; set; }
        //  public string From { get; set; }

        public List<IFormFile>? Attachments { get; set; } = null;
    }
}
