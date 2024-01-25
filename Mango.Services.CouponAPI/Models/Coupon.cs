using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        [Display(Name = "Coupon Code")]
        public string CouponCode { get; set; }
        [Required]
        [Display(Name = "Discount Amount")]
        public double DiscountAmount { get; set; }
        [Display(Name = "Minimum Amount")]
        public int MinAmount { get; set; }
    }
}
