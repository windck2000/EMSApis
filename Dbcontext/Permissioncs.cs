using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSApi.Dbcontext
{
    [Table("SYS_PERMISSIONCS")]
    [Index(nameof(Id),IsUnique =true)]
    public class Permissioncs
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string PermissioncsName { get; set; }
        [MaxLength(20)]
        public string? PermissioncsDescription { get; set; }
        [MaxLength(20)]
        public string?  PermissioncsType { get; set; }
        [MaxLength(50)]
        public string? FunctionsRemarks { get; set; }

        public string? MqIco { get; set; }

        public string? BlIco { get; set; }
    }
}
