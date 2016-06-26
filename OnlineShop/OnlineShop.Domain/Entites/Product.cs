using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineShop.Domain.Entites
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę produktu")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Proszę podać opis produktu")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Proszę podać cenę produktu")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Proszę podać kategorje produktu")]
        public string Category { get; set; }
    }
}
