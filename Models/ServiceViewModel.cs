using System.ComponentModel.DataAnnotations;

namespace LubriSoft.Models
{
    public class ServiceViewModel
    {
        [Required]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Kilometraje Actual")]
        public int KilometrajeActual { get; set; } = 0;

        [Required]
        [Display(Name = "Intervalo")]
        public int Intervalo { get; set; } = 5000;

        [Required]
        [MaxLength(50)]
        [Display(Name = "Aceite")]
        public string Aceite { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^\S+$")]
        [Display(Name = "Filtro de Aire")]
        public string FiltroAire { get; set; } = "NO";

        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^\S+$")]
        [Display(Name = "Filtro de Aceite")]
        public string FiltroAceite { get; set; } = "NO";

        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^\S+$")]
        [Display(Name = "Filtro de Combustible")]
        public string FiltroCombustible { get; set; } = "NO";

        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^\S+$")]
        [Display(Name = "Filtro de Habitaculo")]
        public string FiltroHabitaculo { get; set; } = "NO";

        [Required]
        [MaxLength(100)]
        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; } = "NO";
    }
}