namespace ProjectPRN212.CartModels
{
    public class CartItems
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double? SalePrice { get; set; }
        public int Quantity { get; set; }
        public string Thumbnail { get; set; }
        public double? TotalPrice { get { return SalePrice * Quantity; } }
    }
}
