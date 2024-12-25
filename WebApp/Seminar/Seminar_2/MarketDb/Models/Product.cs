
namespace MarketDb.Models
{
    public partial class Product: BaseModel
    {
        public int? ProductGroupId { get; set; }

        public virtual ProductGroup? ProductGroup { get; set; }

        public decimal? Price { get; set; } = null;

        public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
    }
}
