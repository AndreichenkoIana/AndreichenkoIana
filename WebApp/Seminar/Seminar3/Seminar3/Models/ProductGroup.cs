namespace Seminar3.Models
{
    public partial class ProductGroup: BaseModel
    {
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}