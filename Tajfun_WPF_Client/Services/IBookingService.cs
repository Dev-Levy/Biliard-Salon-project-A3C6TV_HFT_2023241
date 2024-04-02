using A3C6TV_HFT_2023241.Models;

namespace Tajfun_WPF_Client.Services
{
    interface IBookingService
    {
        public void Open(RestCollection<Booking> bookings);
    }
}
