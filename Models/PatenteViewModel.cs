using System.ComponentModel.DataAnnotations;

namespace LubriSoft.Models
{
    public class PatenteViewModel
    {
        [Required]
        [MaxLength(15)]
        [RegularExpression(@"^\S+$")]
        [Display(Name = "Patente")]
        public string Patente { get; set; } = string.Empty;
    }
}