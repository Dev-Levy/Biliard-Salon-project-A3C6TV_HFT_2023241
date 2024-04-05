using A3C6TV_HFT_2023241.Models;

namespace Tajfun_WPF_Client.Services
{
    interface ICustomerService
    {
        public void Open(RestCollection<Customer> customers, RestCollection<Booking> bookings);
    }
}
