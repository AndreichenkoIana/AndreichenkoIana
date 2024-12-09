namespace MarketPlace.Models
{
    public partial class Store
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public Product? Product { get; set; }

        public int Quantity { get; set; }
    }

}
