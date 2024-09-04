using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RestaurantManagementApp.Models.Domain
{
    // Models/Domain/Restaurant.cs
    public class Restaurant
    {
        [Key]
        public int RestaurantID { get; set; }

        [ForeignKey("User")]
        public int OwnerID { get; set; }
        public User Owner { get; set; } // Navigation property to User (Owner)

        [Required, StringLength(100)]
        public string RestaurantName { get; set; }

        [Required, StringLength(255)]
        public string Address { get; set; }

        [Required, StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Required]
        public int TotalTables { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        // Navigation Properties
        // Navigation property for related TableReservations
        public ICollection<TableReservation> TableReservations { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public ICollection<Order> Orders { get; set; }
        //public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
