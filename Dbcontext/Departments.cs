using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSApi.Dbcontext
{
    [Table("SYS_DEPARTMENTS")]
    public class Departments
    {
        [Key]
        public Guid guid { get; set; }
        [Required]
        [MaxLength(20)]
        public string DepartmentsName { get; set; }

        [MaxLength(20)]
        public string? DepartmentsPosition { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
