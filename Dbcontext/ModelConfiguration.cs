using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMSApi.Dbcontext
{
    [Table("SYS_MODELCONFIGURATION")]
    public class ModelConfiguration
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
       public string ModelName { get; set; }
        [Required]
        [MaxLength(50)]
        public string TestItem { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
