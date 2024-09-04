using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementApp.Models.Domain
{
    public class TableReservation
    {
        [Key]
        public int ReservationID { get; set; }

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
        public string ReservationToken { get; set; }

        public DateTime ReservationDate { get; set; } = DateTime.Now;

        [Required, StringLength(20)]
        public string Status { get; set; } // e.g., Confirmed, Pending, Cancelled

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        //public ICollection<OrderDetail> OrderDetails { get; set; }



    }
}
