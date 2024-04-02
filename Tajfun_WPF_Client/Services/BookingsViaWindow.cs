using Tajfun_WPF_Client.Services;

namespace Tajfun_WPF_Client
{
    internal class BookingsViaWindow : IBookingService
    {
        public void Open()
        {
            new Bookings().Show();
        }
    }
}