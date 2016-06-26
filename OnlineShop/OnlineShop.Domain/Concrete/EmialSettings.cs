using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Concrete
{
    public class EmialSettings
    {
        public string MailToAddress;
        public string MailFromAddress = "onlineshop2016v1@outlook.com";
        public bool UseSsl = true;
        public string Username = "onlineshop2016v1@outlook.com";
        public string Password = "Test2016";
        public string ServerName = "smtp-mail.outlook.com";
        public int ServerPort = 587;
    }
}
