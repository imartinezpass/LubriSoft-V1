using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LubriSoft.Entities
{
    [Table("mecanica")]

    public class Mecanica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Column("kmActual")]
        public int KilometrajeActual { get; set; }

        [Column("tipo")]
        [MaxLength(50)]
        public required string TipoTrabajo { get; set; }

        [Column("detalle")]
        [MaxLength(250)]
        public required string Detalle { get; set; }

        //FOREGIN KEYS

        [Column("patente")]
        [MaxLength(15)]
        public required string Patente { get; set; }

        //NAVIGATION PROPERTIES

        public Vehiculo? Vehiculo { get; set; }
    }
}