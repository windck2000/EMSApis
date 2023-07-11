using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSApi.Dbcontext
{
    [Table("SYS_ACCOUNTAPPLICATION")]
    [Index(nameof(Name),nameof(Account),IsUnique =true)]
    public class AccountApplication
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(6)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(6)]
        public string Account { get; set; }

        [MaxLength(20)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime UpdateDateTime { get; set; }
        [MaxLength(1)]
        public string State { get; set; }
    }
}
