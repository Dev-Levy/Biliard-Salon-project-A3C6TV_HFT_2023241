using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A3C6TV_HFT_2023241.Models
{
    public enum TableKind { pool = 1, snooker = 2 }
    public class PoolTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Table_ID { get; set; }

        [Required]
        public TableKind T_kind { get; set; }

    }
}
