﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Settings
{
    public class MailSettings
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string DispalyReciverName { get; set; }
        public string ReciverEmail { get; set; }

        public string Password { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

    }
}
