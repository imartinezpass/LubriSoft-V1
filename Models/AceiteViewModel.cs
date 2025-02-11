using System.ComponentModel.DataAnnotations;

namespace LubriSoft.Models
{
    public class AceiteViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Marca")]
        public string Marca { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Display(Name = "Norma")]
        public string Norma { get; set; } = string.Empty;
    }
}