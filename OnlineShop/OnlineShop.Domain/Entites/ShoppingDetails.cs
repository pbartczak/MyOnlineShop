using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entites
{
    public class ShoppingDetails
    {
        [Required(ErrorMessage = "Proszę podać Imie")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać adres e-mail")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy adres e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę podać adres")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Prosze podać nazwę miasta")]
        public string City { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę województwo")]
        public string State { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "Proszę pdoać kraj")]
        public string Country { get; set; }
        public bool GifWrap { get; set; }
    }
}
