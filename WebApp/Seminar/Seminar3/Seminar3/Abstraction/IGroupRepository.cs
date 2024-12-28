using Seminar3.DTO;

namespace Seminar3.Abstraction
{
    public interface IGroupRepository
    {
        public int AddGroup(ProductGroupDto group);
        public IEnumerable<ProductGroupDto> GetGroups();
    }
}
