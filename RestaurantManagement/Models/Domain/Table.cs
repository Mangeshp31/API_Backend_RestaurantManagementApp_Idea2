using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementApp.Models.Domain
{
    public class Table
    {
        [Key]
        public int TableID { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; } // Navigation property to Restaurant

        [Required]
        public int TableNumber { get; set; }

        [Required, StringLength(20)]
        public string Status { get; set; } // e.g., Available, Occupied, Reserved

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        // Navigation property for related TableReservations
        public ICollection<TableReservation> TableReservations { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
