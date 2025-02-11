using System.ComponentModel.DataAnnotations;

namespace LubriSoft.Models
{
    public class ClienteViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Telefono")]
        [MinLength(10)]
        [MaxLength(10)]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$")]
        public string Telefono { get; set; } = string.Empty;
    }
}