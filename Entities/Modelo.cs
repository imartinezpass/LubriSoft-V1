using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LubriSoft.Entities
{
    [Table("modelos")]

    public class Modelo
    {
        [Key]
        [Column("nombre")]
        [MaxLength(50)]
        public required string Nombre { get; set; }

        //FOREGIN KEYS

        [Column("fabricante")]
        [MaxLength(50)]
        public required string FabricanteId { get; set; }

        //NAVIGATION PROPERTIES

        public Fabricante? Fabricante { get; set; }
    }
}