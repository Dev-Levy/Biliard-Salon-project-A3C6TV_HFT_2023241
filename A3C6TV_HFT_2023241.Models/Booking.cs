using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        //lehetne string is contat *, és fűzögetthetném egymáshoz a fogyaztott dolgokat
    }
}
