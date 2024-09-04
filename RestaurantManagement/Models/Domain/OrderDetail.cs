using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementApp.Models.Domain
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; } // Navigation property to Order

        [ForeignKey("MenuItem")]
        public int MenuItemID { get; set; }
        public MenuItem MenuItem { get; set; } // Navigation property to MenuItem

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
