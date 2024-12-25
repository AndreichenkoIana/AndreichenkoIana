using MarketDb.Models;

namespace MarketDb.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ProductGroupId { get; set; }
        public decimal? Price { get; set; } = null;
    }
}
