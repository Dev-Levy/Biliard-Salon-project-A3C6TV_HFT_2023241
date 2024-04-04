using A3C6TV_HFT_2023241.Models;
using Tajfun_WPF_Client.Services;

namespace Tajfun_WPF_Client
{
    internal class BookingsViaWindow : IBookingService
    {
        public void Open(RestCollection<Booking> bookings)
        {
            new BookingsWindow(bookings).Show();
        }
    }
}