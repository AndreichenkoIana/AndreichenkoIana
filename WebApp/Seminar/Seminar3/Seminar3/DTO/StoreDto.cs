using Seminar3.Models;

namespace Seminar3.DTO
{
    public class StoreDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null;
        public string? Description { get; set; } = null;
        public int? Quantity { get; set; } = null;
    }
}
