using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A3C6TV_HFT_2023241.Models
{
    public enum TableKind { pool = 1, snooker = 2 }
    public class PoolTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TableId { get; set; }

        [Required]
        public TableKind T_kind { get; set; }

        public PoolTable()
        {

        }

        public PoolTable(string line)
        {
            string[] data = line.Split('#');
            TableId = int.Parse(data[0]);
            T_kind = (TableKind)Enum.Parse(typeof(string), data[1]); //idk if this is okey, the internet told me so
        }
    }
}
