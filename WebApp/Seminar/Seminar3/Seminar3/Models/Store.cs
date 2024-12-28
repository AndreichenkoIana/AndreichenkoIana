namespace Seminar3.Models
{
    public partial class Store : BaseModel
    {
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public int? Quantity { get; set; } = null;
    }

}
