using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TsVote.Data.Entities.Gene
{
    [Table("Genders", Schema = "Gene")]
    public class Gender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        [MaxLength(30, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Genero")]
        public string Name { get; set; }
    }
}
