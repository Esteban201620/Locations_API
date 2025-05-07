using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace LocationsAPI.Resources.Models
{
    [Table("Departamento")]
    public class DepartamentoModel
    {
        [Key]
        [Column("DepartamentoId")]
        public int DepartamentoId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("PaisId")]
        [JsonProperty("paisId")]
        public int PaisId { get; set; }

        [ForeignKey("PaisId")]
        public PaisModel Pais { get; set; }

        public ICollection<CiudadModel> Ciudades { get; set; } = [];
    }
}
