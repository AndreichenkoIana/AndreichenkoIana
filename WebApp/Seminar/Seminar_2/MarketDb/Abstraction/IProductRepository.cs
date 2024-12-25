using MarketDb.DTO;
using MarketDb.Models;

namespace MarketDb.Abstraction
{
    public interface IProductRepository
    {
        public int AddProduct (ProductDto product);
        public IEnumerable<ProductDto> GetProducts();
    }
}
