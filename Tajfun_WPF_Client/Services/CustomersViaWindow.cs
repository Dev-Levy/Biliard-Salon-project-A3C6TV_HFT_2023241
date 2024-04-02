namespace Tajfun_WPF_Client.Services
{
    class CustomersViaWindow : ICustomerService
    {
        public void Open(RestCollection<Customers> customers)
        {
            new Customers(customers).Show();
        }
    }
}
