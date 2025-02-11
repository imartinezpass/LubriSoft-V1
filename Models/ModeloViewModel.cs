using System.ComponentModel.DataAnnotations;

namespace LubriSoft.Models
{
    public class ModeloViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Display(Name = "Fabricante")]
        public string Fabricante { get; set; } = string.Empty;
    }
}