using System;
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
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }



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

            //parsing from yyyy-MM-dd HH:mm format string to DateTime 
            //so i can compare them
            var startDateAndTime = startDate.Split(' ');
            var date1 = startDateAndTime[0].Split('-');
            var time1 = startDateAndTime[1].Split(":");
            StartDate = new DateTime(year: int.Parse(date1[0]), month: int.Parse(date1[1]), day: int.Parse(date1[2]), hour: int.Parse(time1[0]), minute: int.Parse(time1[1]), second: 00);

            var endDateAndTime = endDate.Split(' ');
            var date2 = endDateAndTime[0].Split('-');
            var time2 = endDateAndTime[1].Split(":");
            EndDate = new DateTime(year: int.Parse(date2[0]), month: int.Parse(date2[1]), day: int.Parse(date2[2]), hour: int.Parse(time2[0]), minute: int.Parse(time2[1]), second: 00);

            TableId = t_id;
            CustomerId = cust_id;
        }

        public override string ToString()
        {
            return $"Id: {BookingId} - Date:{StartDate} - {EndDate} - CustomerId: {CustomerId} - TableId: {TableId}";
        }
    }
}
