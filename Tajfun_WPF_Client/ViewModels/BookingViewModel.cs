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
        private int customerId;

        public int CustomerId
        {
            get { return customerId; }
            set { SetProperty(ref customerId, value); }
        }

        private int year; public int Year
        {
            get { return year; }
            set { SetProperty(ref year, value); }
        }
        private int month; public int Month
        {
            get { return month; }
            set { SetProperty(ref month, value); }
        }
        private int day; public int Day
        {
            get { return day; }
            set { SetProperty(ref day, value); }
        }

        private int starthour; public int Starthour
        {
            get { return starthour; }
            set { SetProperty(ref starthour, value); }
        }
        private int startminute; public int Startminute
        {
            get { return startminute; }
            set { SetProperty(ref startminute, value); }
        }

        private int endhour; public int Endhour
        {
            get { return endhour; }
            set { SetProperty(ref endhour, value); }
        }
        private int endminute; public int Endminute
        {
            get { return endminute; }
            set { SetProperty(ref endminute, value); }
        }



        public bool IsSomethingSelected { get; set; } = false;
        public RestCollection<Booking> Bookings { get; set; }
        public RestCollection<Customer> Customers { get; set; }
        public RestCollection<PoolTable> PoolTables { get; set; }

        private Booking selectedBooking;
        public Booking SelectedBooking
        {
            get { return selectedBooking; }
            set
            {
                if (value != null)
                {
                    UpdateDatabse();
                    selectedBooking = new Booking()
                    {
                        BookingId = value.BookingId,
                        TableId = value.TableId,
                        PoolTable = value.PoolTable,
                        Customer = value.Customer,
                    };
                    Year = value.StartDate.Year;
                    Month = value.StartDate.Month;
                    Day = value.StartDate.Day;

                    Starthour = value.StartDate.Hour;
                    Startminute = value.StartDate.Minute;
                    Endhour = value.EndDate.Hour;
                    Endminute = value.EndDate.Minute;

                    IsSomethingSelected = true;
                    OnPropertyChanged();
                }
                else
                {
                    selectedBooking = new Booking();
                    IsSomethingSelected = false;
                }
                (DeleteBookingCommand as RelayCommand)?.NotifyCanExecuteChanged();
                //(UpdateBookingCommand as RelayCommand)?.NotifyCanExecuteChanged();
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
        public BookingViewModel(RestCollection<Booking> bookings, RestCollection<Customer> customers, RestCollection<PoolTable> poolTables)
        {
            if (!IsInDesignMode)
            {
                Bookings = bookings;
                Customers = customers;
                PoolTables = poolTables;

                CreateBookingCommand = new RelayCommand(
                    () => Bookings.Add(new Booking()
                    {
                        StartDate = new DateTime(Year, Month, Day, Starthour, Startminute, 0),
                        EndDate = new DateTime(Year, Month, Day, Endhour, Endminute, 0),
                        TableId = SelectedBooking.TableId,
                        PoolTable = SelectedBooking.PoolTable,
                        CustomerId = SelectedBooking.CustomerId,
                        Customer = SelectedBooking.Customer
                    }));

                DeleteBookingCommand = new RelayCommand(
                    async () =>
                    {
                        await Bookings.Delete(SelectedBooking.BookingId);
                        IsSomethingSelected = false;
                    },
                    () => IsSomethingSelected == true
                    );

                UpdateBookingCommand = new RelayCommand(
                    () =>
                    {
                        UpdateDatabse();
                    },
                    () => IsSomethingSelected == true
                    );
            }
        }

        private void UpdateDatabse()
        {
            if (SelectedBooking == null)
            {
                return;
            }

            SelectedBooking.StartDate = new DateTime(Year, Month, Day, Starthour, Startminute, 0);
            SelectedBooking.EndDate = new DateTime(Year, Month, Day, Endhour, Endminute, 0);
            SelectedBooking.CustomerId = SelectedBooking.Customer.CustomerId;
            try
            {
                Bookings.Update(SelectedBooking);
            }
            catch (System.Exception)
            {
                ; // Log error
            }
        }
    }
}
