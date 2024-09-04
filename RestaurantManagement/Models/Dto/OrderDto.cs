namespace RestaurantManagementApp.Models.Dto
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public int RestaurantID { get; set; }
        public int CustomerID { get; set; }
        public int? TableID { get; set; }
        public string OrderToken { get; set; }
        public decimal OrderAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderStatus { get; set; }
    }
}
