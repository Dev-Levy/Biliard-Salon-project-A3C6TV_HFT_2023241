using A3C6TV_HFT_2023241.Models;
using System.Windows;
using Tajfun_WPF_Client.ViewModels;

namespace Tajfun_WPF_Client
{
    /// <summary>
    /// Interaction logic for Bookings.xaml
    /// </summary>
    public partial class Bookings : Window
    {
        public Bookings(RestCollection<Booking> bookings)
        {
            DataContext = new BookingViewModel(bookings);
            InitializeComponent();
        }
    }
}
