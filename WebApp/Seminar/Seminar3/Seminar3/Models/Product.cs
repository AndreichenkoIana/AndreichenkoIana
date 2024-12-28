using Seminar3.Models;

namespace Seminar3.Models
{
    public partial class Product : BaseModel
    {
        public int? ProductGroupId { get; set; }

        public virtual ProductGroup? ProductGroup { get; set; }

        public decimal? Price { get; set; } = null;
        public int? Count { get; set; } = null;
        public int? StoreID { get; set; } = null;
        public virtual Store? Store { get; set; }

    }
}
