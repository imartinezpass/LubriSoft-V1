using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LubriSoft.Entities
{
    [Table("vehiculos")]

    public class Vehiculo
    {
        [Key]
        [Column("patente")]
        [MaxLength(15)]
        public string? Patente { get; set; }

        [Column("version")]
        [MaxLength(50)]
        public string? Version { get; set; }

        [Column("capacidadMotor")]
        [MaxLength(10)]
        public string? CapacidadMotor { get; set; }

        [Column("capacidadCaja")]
        [MaxLength(10)]
        public string? CapacidadCaja { get; set; }

        //FOREGIN KEYS

        [Column("fabricante")]
        [MaxLength(50)]
        public required string FabricanteId { get; set; }

        [Column("modelo")]
        [MaxLength(50)]
        public required string ModeloId { get; set; }

        [Column("clienteId")]
        [MaxLength(20)]
        public string? ClienteId { get; set; }

        //NAVIGATION PROPERTIES

        public Fabricante? Fabricante { get; set; }

        public Modelo? Modelo { get; set; }

        public Cliente? Cliente { get; set; }
    }
}