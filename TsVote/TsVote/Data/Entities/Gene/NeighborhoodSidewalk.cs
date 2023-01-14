using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TsVote.Data.Entities.Gene
{
    [Table("NeighborhoodSidewalks", Schema = "Gene")]
    public class NeighborhoodSidewalk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Comuna/Corregimiento")]
        public CommuneTownship CommuneTownship { get; set; }

        [Column(TypeName = "varchar(50)")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Barrio/vereda")]
        public string Name { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}