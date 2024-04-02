using A3C6TV_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Tajfun_WPF_Client.ViewModels
{
    internal class BookingViewModel : ObservableRecipient
    {
        public RestCollection<Booking> Bookings { get; set; }

        private Booking selectedBookings;

        public Booking SelectedBookings
        {
            get { return selectedBookings; }
            set
            {
                if (value != null)
                {
                    selectedBookings = new Booking() //ez egy gány megoldás szerintem
                    {

                    };
                    OnPropertyChanged();

                    //SetProperty(ref selectedCustomer, value); //ez lenne helyette, de hibás az update

                    (DeleteBookingCommand as RelayCommand)?.NotifyCanExecuteChanged();
                    (UpdateBookingCommand as RelayCommand)?.NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateBookingCommand { get; set; }
        public ICommand DeleteBookingCommand { get; set; }
        public ICommand UpdateBookingCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public BookingViewModel(RestCollection<Booking> bookings)
        {
            SelectedBookings = new Booking();
            if (!IsInDesignMode)
            {
                Bookings = bookings;


            }

        }
    }
}
