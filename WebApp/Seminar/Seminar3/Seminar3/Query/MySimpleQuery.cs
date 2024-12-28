using Seminar3.Abstraction;
using Seminar3.DTO;

namespace Seminar3.Query
{
    public class MySimpleQuery
    {
        public IEnumerable<ProductDto> GetProduct([Service] IProductRepository service) => service.GetProducts();
        public IEnumerable<ProductGroupDto> GetGroups([Service] IGroupRepository service) => service.GetGroups();

        public IEnumerable<ProductDto> GetProductsByGroupId(int groupId, [Service] IProductRepository service)
            => service.GetProductsByGroupId(groupId);
        public IEnumerable<StoreDto> GetStores([Service] IStoreRepository service) => service.GetStores();
        public IEnumerable<ProductDto> GetProductsByStoreID(int storeId, [Service] IProductRepository service)
            => service.GetProductsByStoreID(storeId);
    }
}
