using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMSApi.Dbcontext
{
    [Table("SYS_MODEL")]
    [Index(nameof(ModelName),IsUnique = true)]
    public class Model
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string ModelName { get; set; }
        [MaxLength(50)]
        public string? ModelDescription { get; set; }


        public DateTime UpdateTime { get; set; }
    }
}
