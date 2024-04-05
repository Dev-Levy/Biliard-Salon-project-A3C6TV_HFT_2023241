using A3C6TV_HFT_2023241.Models;
using System.Windows;
using Tajfun_WPF_Client.ViewModels;

namespace Tajfun_WPF_Client
{
    /// <summary>
    /// Interaction logic for BookingsWindow.xaml
    /// </summary>
    public partial class BookingsWindow : Window
    {
        public BookingsWindow(RestCollection<Booking> bookings, RestCollection<Customer> customers, RestCollection<PoolTable> poolTables)
        {
            DataContext = new BookingViewModel(bookings, customers, poolTables);
            InitializeComponent();
        }
    }
}
