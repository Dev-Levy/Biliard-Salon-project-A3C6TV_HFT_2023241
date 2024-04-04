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
        public bool IsSomethingSelected { get; set; } = false;
        public RestCollection<Booking> Bookings { get; set; }

        private Booking selectedBooking;
        public Booking SelectedBooking
        {
            get { return selectedBooking; }
            set
            {
                if (value != null)
                {
                    selectedBooking = new Booking()
                    {
                        BookingId = value.BookingId,
                        StartDate = value.StartDate,
                        EndDate = value.EndDate,
                        TableId = value.TableId,
                        PoolTable = value.PoolTable,
                        CustomerId = value.CustomerId,
                        Customer = value.Customer
                    };
                    IsSomethingSelected = true;
                    OnPropertyChanged();
                }
                else
                {
                    selectedBooking = new Booking();
                    IsSomethingSelected = false;
                }
                (DeleteBookingCommand as RelayCommand)?.NotifyCanExecuteChanged();
                (UpdateBookingCommand as RelayCommand)?.NotifyCanExecuteChanged();
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

        public BookingViewModel()
        {

        }

        public BookingViewModel(RestCollection<Booking> bookings)
        {
            if (!IsInDesignMode)
            {
                Bookings = bookings;

                CreateBookingCommand = new RelayCommand(
                    () => Bookings.Add(new Booking()
                    {
                        //StartDate = value.StartDate,
                        //EndDate = value.EndDate,
                        TableId = SelectedBooking.TableId,
                        PoolTable = SelectedBooking.PoolTable,
                        CustomerId = SelectedBooking.CustomerId,
                        Customer = SelectedBooking.Customer
                    }),
                    () => true
                    );

                DeleteBookingCommand = new RelayCommand(
                    async () =>
                    {
                        await Bookings.Delete(SelectedBooking.BookingId);
                        IsSomethingSelected = false;
                    },
                    () => IsSomethingSelected != false
                    );

                UpdateBookingCommand = new RelayCommand(
                    () => Bookings.Update(SelectedBooking),
                    () => IsSomethingSelected != false
                    );
            }
        }
    }
}
