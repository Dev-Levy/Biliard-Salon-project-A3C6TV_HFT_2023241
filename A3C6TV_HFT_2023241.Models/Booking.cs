using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A3C6TV_HFT_2023241.Models
{
    internal class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Booking_ID { get; set; }


        public DateTime StartDate { get; set; }
        public int Duration { get; set; }

        public int Table_ID { get; set; }

        public int Customer_ID { get; set; }

        public int[] Consumed { get; set; }
        //lehetne string is contat *, és fűzögetthetném egymáshoz a fogyaztott dolgokat
    }
}
