using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMSApi.Dbcontext
{
    [Table("SYS_TESTERMACHINE")]
    [Index(nameof(MacgineName),IsUnique = true)]
    public class TesterMachine
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string MacgineName { get; set; }
        [Required]
        [MaxLength(20)]
        public string MacgineCode { get; set; }

        [MaxLength(20)]
        public string? MacgineVersion { get; set; }
        [Required]
        [MaxLength(5)]
        public string MacgineState { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
