using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMSApi.Dbcontext
{
    [Table("SYS_TESTITEM")]
    [Index(nameof(TestName),IsUnique = true)]
    public class TestItem
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string TestName { get; set; }
        [MaxLength(20)]
        public string? TestDescription { get; set; }
        [MaxLength(20)]
        public string  Identifier { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
