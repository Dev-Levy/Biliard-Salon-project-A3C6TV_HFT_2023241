using System.Windows;

namespace Tajfun_WPF_Client
{
    /// <summary>
    /// Interaction logic for Bookings.xaml
    /// </summary>
    public partial class Bookings : Window
    {
        public Bookings(RestCollection<Bookings> bookings)
        {
            DataContext = bookings;
            InitializeComponent();
        }
    }
}
