using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementApp.Models.Domain
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; } // Navigation property to Restaurant

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; } // Navigation property to Customer

        [ForeignKey("Table")]
        public int? TableID { get; set; }
        public Table Table { get; set; } // Navigation property to Table

        [Required, StringLength(50)]
        public string OrderToken { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public decimal OrderAmount { get; set; }

        [Required, StringLength(20)]
        public string PaymentStatus { get; set; } // e.g., Paid, Pending

        [Required, StringLength(20)]
        public string OrderStatus { get; set; } // e.g., Pending, Accepted, Completed

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        // Navigation Properties
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
