using System.Windows;

namespace Tajfun_WPF_Client
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Window
    {
        public Customers(RestCollection<Customers> customers)
        {
            DataContext = customers;
            InitializeComponent();
        }
    }
}
