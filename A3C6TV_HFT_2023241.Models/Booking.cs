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

        public int? CustomerId { get; set; }

        public string Consumed { get; set; }
        //lehetne string is contat *, és fűzögetthetném egymáshoz a fogyasztott dolgokat

        public Booking()
        {

        }

        public Booking(string line)
        {
            string[] data = line.Split('#');
            BookingId = int.Parse(data[0]);
            StartDate = data[1];
            EndDate = data[2];
            TableId = int.Parse(data[3]);
            CustomerId = int.Parse(data[4]);
            Consumed = data[5];
        }
    }
}
