using System.ComponentModel.DataAnnotations;

namespace LubriSoft.Models
{
    public class VehiculoViewModel
    {
        [Required]
        [MaxLength(15)]
        [RegularExpression(@"^\S+$")]
        [Display(Name = "Patente")]
        public string Patente { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Display(Name = "Fabricante")]
        public string Fabricante { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modelo")]
        public string Modelo{ get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Display(Name = "Version")]
        public string Version { get; set; } = string.Empty;

        [MaxLength(10)]
        [Display(Name = "Capacidad Motor")]
        public string CapacidadMotor { get; set; } = string.Empty;

        [MaxLength(10)]
        [Display(Name = "Capacidad Caja")]
        public string CapacidadCaja { get; set; } = string.Empty;

        [MaxLength(10)]
        [Display(Name = "Cliente")]
        public string? ClienteId { get; set; } 
    }
}