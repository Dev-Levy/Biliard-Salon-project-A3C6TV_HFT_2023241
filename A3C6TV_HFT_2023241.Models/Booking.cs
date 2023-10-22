using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace A3C6TV_HFT_2023241.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Booking_ID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        public int? Table_ID { get; set; }

        public int? Customer_ID { get; set; }

        public int?[] Consumed { get; set; }
        //lehetne string is contat *, és fűzögetthetném egymáshoz a fogyasztott dolgokat

        public Booking()
        {
            
        }

        public Booking(string line)
        {
            string[] data = line.Split('#');
            Booking_ID = int.Parse(data[0]);
            StartDate = DateTime.ParseExact(data[1], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture); // itt lehet majd formátumprobléma
            EndDate = DateTime.ParseExact(data[2], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            Table_ID = int.Parse(data[3]);
            Customer_ID = int.Parse(data[4]);

            string[] Consum = data[5].Split(',');
            for (int i = 0; i < Consum.Length; i++)
            {
                Consumed[i] = int.Parse(Consum[i]);
            }
        }
    }
}
