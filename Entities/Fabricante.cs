using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LubriSoft.Entities
{
    [Table("fabricantes")]

    public class Fabricante
    {
        [Key]
        [Column("nombre")]
        [MaxLength(50)]
        public required string Nombre { get; set; }
    }
}