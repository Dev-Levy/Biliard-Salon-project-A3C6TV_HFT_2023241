using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace A3C6TV_HFT_2023241.Models
{
    public class PoolTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TableId { get; set; }

        [Required]
        public string T_kind { get; set; }

        [JsonIgnore]
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

        public override string ToString()
        {
            return $"Id: {TableId} type: {T_kind}";
        }

        public override bool Equals(object obj)
        {
            return obj is PoolTable table &&
                   TableId == table.TableId &&
                   T_kind == table.T_kind;
        }
    }
}
