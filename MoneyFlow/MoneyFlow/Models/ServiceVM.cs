using MoneyFlow.Entities;
using System.ComponentModel.DataAnnotations;

namespace MoneyFlow.Models
{
    public class ServiceVM
    {

        public int ServiceId { get; set; }

        public int UserId { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        public string Type { get; set; } = string.Empty;
    }
}
