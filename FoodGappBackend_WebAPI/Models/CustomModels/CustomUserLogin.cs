using System.ComponentModel.DataAnnotations;

namespace FoodGappBackend_WebAPI.Models.CustomModels
{
    public class CustomUserLogin
    {
        [StringLength(100)]
        public string? UserEmail { get; set; }

        [StringLength(100)]
        public string? UserPassword { get; set; }
    }
}
