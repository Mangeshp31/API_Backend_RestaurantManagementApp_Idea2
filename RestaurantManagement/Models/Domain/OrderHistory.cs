using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementApp.Models.Domain
{
    public class OrderHistory
    {
        [Key]
        public int OrderHistoryID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; } // Navigation property to Order

        public DateTime StatusChangeDate { get; set; } = DateTime.Now;

        [Required, StringLength(20)]
        public string OldStatus { get; set; } // Previous status

        [Required, StringLength(20)]
        public string NewStatus { get; set; } // Updated status

        [StringLength(255)]
        public string Remarks { get; set; } // Optional remarks for status change

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
