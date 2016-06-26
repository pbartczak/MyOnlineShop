using OnlineShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Porducts { get; }

        void SaveProduct(Product product);
        Product DeleteProduct(int productId);
    }
}
