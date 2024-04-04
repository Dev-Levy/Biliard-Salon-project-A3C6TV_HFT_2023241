using A3C6TV_HFT_2023241.Models;

namespace Tajfun_WPF_Client.Services
{
    class CustomersViaWindow : ICustomerService
    {
        public void Open(RestCollection<Customer> customers)
        {
            new CustomersWindow(customers).Show();
        }
    }
}
