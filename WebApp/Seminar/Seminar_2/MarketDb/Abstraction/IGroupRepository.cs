using MarketDb.DTO;
using MarketDb.Models;

namespace MarketDb.Abstraction
{
    public interface IGroupRepository
    {
        public int AddGroup(ProductGroupDto group);
        public IEnumerable<ProductGroupDto> GetGroups();
    }
}
