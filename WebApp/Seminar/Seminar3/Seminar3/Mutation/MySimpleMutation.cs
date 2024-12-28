using Seminar3.Abstraction;
using Seminar3.DTO;

namespace Seminar3.Mutation
{
    public class MySimpleMutation
    {
        public int AddProduct (ProductDto product, [Service] IProductRepository service )
        {
            var id = service.AddProduct ( product );
            return id;
        }
        public int AddStore(StoreDto store, [Service] IStoreRepository service )
        {
            var id = service.AddStore ( store );
            return id;
        }
    }
}
