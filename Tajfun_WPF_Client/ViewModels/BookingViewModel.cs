using A3C6TV_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Tajfun_WPF_Client.ViewModels
{
    class BookingViewModel : ObservableRecipient
    {
        public RestCollection<Booking> Bookings { get; set; }

        private Booking selectedBooking;

        public Booking SelectedBooking
        {
            get { return selectedBooking; }
            set
            {
                if (value != null)
                {
                    selectedBooking = new Booking() //ez egy gány megoldás szerintem
                    {
                        StartDate = value.StartDate,
                        EndDate = value.EndDate,
                        PoolTable = value.PoolTable,
                        Customer = value.Customer
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
            SelectedBooking = new Booking();
            if (!IsInDesignMode)
            {
                Bookings = bookings;


            }

        }
    }
}
