using A3C6TV_HFT_2023241.Models;
using System.Windows;
using Tajfun_WPF_Client.ViewModels;

namespace Tajfun_WPF_Client
{
    /// <summary>
    /// Interaction logic for CustomersWindow.xaml
    /// </summary>
    public partial class CustomersWindow : Window
    {
        public CustomersWindow(RestCollection<Customer> customers)
        {
            DataContext = new CustomerViewModel(customers);
            InitializeComponent();
        }
    }
}
