using Seminar3.DTO;

namespace Seminar3.Abstraction
{
    public interface IStoreRepository
    {
        public int AddStore(StoreDto store);
        public IEnumerable<StoreDto> GetStores();
    }
}
