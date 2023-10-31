using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A3C6TV_HFT_2023241.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [Required]
        public string StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }



        public int? TableId { get; set; }
        public virtual PoolTable PoolTable { get; set; }



        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }



        public Booking()
        {

        }

        public Booking(int id, string startDate, string endDate, int t_id, int cust_id)
        {
            BookingId = id;
            StartDate = startDate;
            EndDate = endDate;
            TableId = t_id;
            CustomerId = cust_id;
        }
    }
}
