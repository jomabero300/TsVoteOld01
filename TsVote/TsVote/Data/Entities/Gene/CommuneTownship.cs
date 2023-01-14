using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TsVote.Data.Entities.Gene
{
    [Table("CommuneTownships", Schema = "Gene")]
    public class CommuneTownship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Municipio")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Zona")]
        public int ZoneId { get; set; }

        [Column(TypeName = "varchar(80)")]
        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Descripción")]
        public string Name { get; set; }

        public ICollection<NeighborhoodSidewalk> NeighborhoodSidewalks { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual City City { get; set; }
    }
}