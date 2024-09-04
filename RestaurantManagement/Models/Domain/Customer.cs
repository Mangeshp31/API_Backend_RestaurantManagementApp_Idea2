using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementApp.Models.Domain
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; } // Navigation property to Restaurant

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(15)]
        public string PhoneNumber { get; set; }

        [EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property for related TableReservations
        public ICollection<TableReservation> TableReservations { get; set; }
        public ICollection<Order> Orders { get; set; }
        //public ICollection<OrderDetail> OrderDetail { get; set; }

    }
}
