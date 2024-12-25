using MarketDb.DTO;
using MarketDb.Models;

namespace MarketDb.Abstraction
{
    public interface IProductRepository
    {
        public int AddProduct (ProductDto product);
        bool DeleteProduct(int id);
        public IEnumerable<ProductDto> GetProducts();
    }
}
