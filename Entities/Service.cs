using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LubriSoft.Entities
{
    [Table("service")]

    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Column("kmActual")]
        public int KilometrajeActual { get; set; }

        [Column("kmProximo")]
        public int KilometrajeProximo { get; set; }

        [Column("filtroAire")]
        [MaxLength(20)]
        public string? FiltroAire { get; set; }

        [Column("filtroAceite")]
        [MaxLength(20)]
        public string? FiltroAceite { get; set; }

        [Column("filtroCombustible")]
        [MaxLength(20)]
        public string? FiltroCombustible { get; set; }

        [Column("filtroHabitaculo")]
        [MaxLength(20)]
        public string? FiltroHabitaculo { get; set; }

        [Column("observaciones")]
        [MaxLength(100)]
        public string? Observaciones { get; set; }

        //FOREGIN KEYS

        [Column("patente")]
        [MaxLength(15)]
        public required string Patente { get; set; }

        [Column("aceite")]
        [MaxLength(150)]
        public required string AceiteId { get; set; }

        //NAVIGATION PROPERTIES

        public Vehiculo? Vehiculo { get; set; }

        public Aceite? Aceite { get; set; } 
    }
}