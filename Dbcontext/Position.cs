using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSApi.Dbcontext
{
    [Table("SYS_POSITION")]
    [Index(nameof(PositionName),nameof(Id),IsUnique = true)]
    public class Position
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string DepartmentName { get; set; }
        [MaxLength(20)]
        public string PositionName { get; set; }

        public DateTime PositionUpdateDate { get; set; }

    }
}
