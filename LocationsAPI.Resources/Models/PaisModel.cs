using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationsAPI.Resources.Models
{
    [Table("Pais")]
    public class PaisModel
    {
        [Key]
        [Column("PaisId")]
        public int PaisId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Nombre")]
        public string Nombre { get; set; }

        public ICollection<DepartamentoModel> Departamentos { get; set; } = [];
    }
}
