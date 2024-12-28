
namespace Seminar3.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ProductGroupId { get; set; }
        public int? Count { get; set; } = null;
        public decimal? Price { get; set; } = null;
        public int StoreID { get; set; }
    }
}
