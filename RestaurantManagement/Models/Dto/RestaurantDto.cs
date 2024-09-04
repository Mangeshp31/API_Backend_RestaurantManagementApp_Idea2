namespace RestaurantManagementApp.Models.Dto
{
    public class RestaurantDto
    {
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int TotalTables { get; set; }
    }
}
