using System.Data.SqlTypes;

namespace MarketPlace.Models
{
    public partial class Product
    {
        public int Id { get; set; }

        public int? ProductGroupId { get; set; }

        public ProductGroup? ProductGroup { get; set; }

        public string? Name { get; set; } = null;

        public string? Description { get; set; } = null;
        public string? Price { get; set; } = null;

        public ICollection<Store> Stores { get; set; } = new List<Store>();

    }
}
