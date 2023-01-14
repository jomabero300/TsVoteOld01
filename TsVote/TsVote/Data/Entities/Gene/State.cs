using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TsVote.Data.Entities.Gene
{
    [Table("States", Schema = "Gene")]
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonIgnore]
        [Display(Name = "País")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Country Country { get; set; }

        [Column(TypeName = "varchar(100)")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Departamento/Estado")]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }

        [Display(Name = "Ciudades")]
        public int CityNumber => Cities == null ? 0 : Cities.Count;
    }
}
