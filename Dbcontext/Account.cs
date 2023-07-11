using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSApi.Dbcontext
{
    [Table("SYS_ACCOUNT")]
    [Index(nameof(Name),nameof(Id),nameof(Accounts),IsUnique = true)]
    public class Account
    {
        [Key]
        [MaxLength(20)]
        public int Id { get; set; }
        [MaxLength(6)]
        public string Name { get; set; }
        [MaxLength(6)]
        public string Accounts { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
       
        public DateTime CreationDate { get; set; }
        
        public string Password { get; set; }
        [MaxLength(10)]
        public string permission { get; set; }
        [MaxLength(10)]
        public string Department { get; set; }
        [MaxLength(2)]
        public string Gender { get; set; }

        public int Ownness { get; set; }

        [MaxLength(6)]
        public string Position { get; set; }

        public string? Avatar { get; set; }

    }
}
