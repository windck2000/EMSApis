using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMSApi.Dbcontext
{
    [Table("SYS_SETTING")]

    public class Setting
    {
        [Key]
        [StringLength(50)]
        public string SettingName { get; set; }
        [StringLength(50)]
        public string? SettingValue { get; set; }
    }
}
