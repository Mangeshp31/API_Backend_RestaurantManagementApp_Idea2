using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = ServiceStack.DataAnnotations.RequiredAttribute;
using StringLengthAttribute = ServiceStack.DataAnnotations.StringLengthAttribute;
using ForeignKeyAttribute = ServiceStack.DataAnnotations.ForeignKeyAttribute;

namespace RestaurantManagementApp.Models.Domain
{
    // Models/Domain/Restaurant.cs
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required, StringLength(100)]
        public string Username { get; set; }

        [Required, StringLength(255)]
        public string PasswordHash { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(20)]
        public string Role { get; set; } // e.g., "Owner", "Customer"

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        // Navigation Property
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}



    // Similar domain models for MenuItem, Table, Customer, Order, OrderDetail, TableReservation, OrderHistory

