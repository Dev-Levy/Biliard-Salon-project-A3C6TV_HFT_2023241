using System;

namespace A3C6TV_HFT_2023241.Models
{
    public interface IBooking
    {
        int BookingId { get; set; }
        Customer Customer { get; set; }
        int? CustomerId { get; set; }
        DateTime EndDate { get; set; }
        PoolTable PoolTable { get; set; }
        DateTime StartDate { get; set; }
        int? TableId { get; set; }

        string ToString();
    }
}