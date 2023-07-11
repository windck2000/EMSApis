using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSApi.Dbcontext
{
    [Table("SYS_PROJECTFILE")]
    public class Files
    {
        [Key]
        public Guid Guid { get; set; }
        [MaxLength(20)]
        public string FileName { get; set; }
        [MaxLength(20)]
        public string ProjectId { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
