namespace RestaurantManagementApp.Models.Dto
{
    public class MenuItemDto
    {
        public int MenuItemID { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }
        public int ExpectedCookingTime { get; set; }
    }
}
