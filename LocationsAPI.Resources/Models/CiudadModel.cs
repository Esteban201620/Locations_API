using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LocationsAPI.Resources.Models
{
    [Table("Ciudad")]
    public class CiudadModel
    {
        [Key]
        [Column("CiudadId")]
        public int CiudadId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("DepartamentoId")]
        public int DepartamentoId { get; set; }

        [ForeignKey("DepartamentoId")]
        public DepartamentoModel Departamento { get; set; }
    }
}
