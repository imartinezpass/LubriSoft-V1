using System.ComponentModel.DataAnnotations;

namespace LubriSoft.Models
{
    public class MecanicaViewModel
    {
        [Required]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Kilometraje Actual")]
        public int KilometrajeActual { get; set; } = 0;

        [Required]
        [MaxLength(50)]
        [Display(Name = "Tipo de Trabajo")]
        public string TipoTrabajo { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        [Display(Name = "Detalle")]
        public string Detalle { get; set; } = string.Empty;
    }
}