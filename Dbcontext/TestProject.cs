using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMSApi.Dbcontext
{
    [Table("SYS_TESTPROJECT")]
    public class TestProject
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string ProjectNo { get; set; }
        [MaxLength(20)]
        public string ProjectSource { get; set; }
        [MaxLength(20)]
        public string TestDemand { get; set; }

        public int TestState { get; set; }
        [MaxLength(10)]
        public string UpdateUser { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
