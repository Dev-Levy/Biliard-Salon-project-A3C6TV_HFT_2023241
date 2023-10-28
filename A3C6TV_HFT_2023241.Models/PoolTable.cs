using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A3C6TV_HFT_2023241.Models
{
    public class PoolTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TableId { get; set; }

        [Required]
        public string T_kind { get; set; }

        public PoolTable()
        {

        }

        public PoolTable(string line)
        {
            string[] data = line.Split('#');
            TableId = int.Parse(data[0]);
            T_kind = data[1];
        }
    }
}
