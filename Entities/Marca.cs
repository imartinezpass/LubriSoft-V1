using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LubriSoft.Entities
{
    [Table("marcas")]

    public class Marca
    {
        [Key]
        [Column("nombre")]
        [MaxLength(50)]
        public required string Nombre { get; set; }
    }
}