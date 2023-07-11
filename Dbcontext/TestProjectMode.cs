using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMSApi.Dbcontext
{
    [Table("SYS_TESTPROJECTMODE")]
    public class TestProjectMode
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string ProjectNo { get; set; }

        [MaxLength(20)]
        public string TestMode { get; set; }
        [MaxLength(50)]
        public string? TestItem { get; set; }
        [MaxLength(20)]
        public string? TestSite { get; set; }
        [MaxLength(20)]
        public string? TestEquipment { get; set; }
        [MaxLength(10)]
        public string? TestUser { get; set; }

        public int TestPotlife { get; set; }

        public int TestQty { get; set; }

        public int TestState { get; set; }

        public DateTime UpdateTime { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
