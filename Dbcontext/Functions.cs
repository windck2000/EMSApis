using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSApi.Dbcontext
{
    [Table("SYS_FUNCTIONS")]
    public class Functions
    {

        [MaxLength(20)]
        public string FunctionsName { get; set; }
        [Key]
        [MaxLength(20)]
        public string FunctionsSublevel { get; set; }
        [MaxLength(50)]
        public string? FunctionsRemarks { get; set; }

        public string MqIco { get; set; }

        public string BlIco { get; set; }

    }
}
