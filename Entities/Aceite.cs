using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LubriSoft.Entities
{
    [Table("aceites")]

    public class Aceite
    {
        [Key]
        [Column("nombreCompleto")]
        [MaxLength(150)]
        public required string NombreCompleto { get; set; }

        [Column("nombre")]
        [MaxLength(50)]
        public required string Nombre { get; set; }

        [Column("norma")]
        [MaxLength(50)]
        public required string Norma { get; set; }

        //FOREGIN KEYS

        [Column("marca")]
        [MaxLength(50)]
        public required string MarcaId { get; set; }

        //NAVIGATION PROPERTIES

        public Marca? Marca { get; set; }
    }
}