using System.Collections.Generic;
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
        public virtual ICollection<Booking> Bookings { get; set; }

        public PoolTable()
        {

        }

        public PoolTable(int id, string tableType)
        {
            TableId = id;
            T_kind = tableType;
            Bookings = new HashSet<Booking>();
        }
    }
}
