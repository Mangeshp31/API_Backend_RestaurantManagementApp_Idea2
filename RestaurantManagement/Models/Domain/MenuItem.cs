using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementApp.Models.Domain
{
    public class MenuItem
    {
        [Key]
        public int MenuItemID { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; } // Navigation property to Restaurant

        [Required, StringLength(100)]
        public string ItemName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool Availability { get; set; } = true;

        [Required]
        public int ExpectedCookingTime { get; set; } // In minutes

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
