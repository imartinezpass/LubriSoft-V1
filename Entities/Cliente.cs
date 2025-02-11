using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LubriSoft.Entities
{
    [Table("clientes")]

    public class Cliente
    {
        [Key]
        [Column("telefono")]
        [MaxLength(20)]
        public required string Telefono { get; set; }

        [Column("nombre")]
        [MaxLength(50)]
        public required string Nombre { get; set; }
    }
}