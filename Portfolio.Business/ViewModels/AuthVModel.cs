using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.ViewModels
{
    public class AuthVModel
    {

        public bool isAouthentecated { get; set; }

        public string Message { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public List<string>? Roles { get; set; }
    }
}
