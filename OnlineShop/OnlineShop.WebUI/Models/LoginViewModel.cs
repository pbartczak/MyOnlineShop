using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Login jest wymagany")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Haslo jest wymagane")]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
