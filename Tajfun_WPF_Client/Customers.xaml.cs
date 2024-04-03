using A3C6TV_HFT_2023241.Models;
using System.Windows;

namespace Tajfun_WPF_Client
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Window
    {
        public Customers(RestCollection<Customer> customers)
        {
            DataContext = new ViewModels.CustomerViewModel(customers);
            InitializeComponent();
        }
    }
}
