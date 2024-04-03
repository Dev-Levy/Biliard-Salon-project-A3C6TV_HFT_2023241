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
                SetProperty(ref selectedBooking, value);
                //if (value != null)
                //{
                //    selectedBooking = new Booking()
                //    {
                //        BookingId = value.BookingId,
                //        StartDate = value.StartDate,
                //        EndDate = value.EndDate,
                //        TableId = value.TableId,
                //        PoolTable = value.PoolTable,
                //        CustomerId = value.CustomerId,
                //        Customer = value.Customer
                //    };
                //    OnPropertyChanged();
                //}
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
            SelectedBooking = new Booking();
            if (!IsInDesignMode)
            {
                Bookings = bookings;

                CreateBookingCommand = new RelayCommand(
                    () => Bookings.Add(new Booking()
                    {
                        //ide kellenek a mezők
                    }),
                    () => true
                    );
                DeleteBookingCommand = new RelayCommand(
                    () => Bookings.Delete(SelectedBooking.BookingId),
                    () => SelectedBooking != null
                    );

                UpdateBookingCommand = new RelayCommand(
                    () => Bookings.Update(SelectedBooking),
                    () => SelectedBooking != null
                    );
            }
        }
    }
}
