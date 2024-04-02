namespace Tajfun_WPF_Client.Services
{
    class CustomersViaWindow : ICustomerService
    {
        public void Open()
        {
            new Customers().Show();
        }
    }
}
