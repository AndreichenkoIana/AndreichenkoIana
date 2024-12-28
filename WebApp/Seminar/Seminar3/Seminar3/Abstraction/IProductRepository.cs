using Seminar3.DTO;

namespace Seminar3.Abstraction
{
    public interface IProductRepository
    {
        public int AddProduct (ProductDto product);
        bool DeleteProduct(int id);
        public IEnumerable<ProductDto> GetProducts();
        public IEnumerable<ProductDto> GetProductsByGroupId(int productGroupId);
        public IEnumerable<ProductDto> GetProductsByStoreID(int storeID);
    }
}
