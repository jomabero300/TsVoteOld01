using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TsVote.Data.Entities.Gene
{
    [Table("Zones", Schema = "Gene")]
    public class Zone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        [MaxLength(20, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        public ICollection<CommuneTownship> CommuneTownships { get; set; }
    }
}