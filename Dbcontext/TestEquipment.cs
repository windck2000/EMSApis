using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMSApi.Dbcontext
{
    [Table("SYS_TESTEQUIPMENT")]
    public class TestEquipment
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(20)]
        public string EquipmentName { get; set; }

        public string EquipmentNo { get; set; }

        public int EquipmentState { get; set; } = 0;
        [MaxLength(10)]
        public string UpdateUser { get; set; }

        public bool IsRepair { get; set; } = false;

        public bool IsIntel { get; set; } = false;

        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
