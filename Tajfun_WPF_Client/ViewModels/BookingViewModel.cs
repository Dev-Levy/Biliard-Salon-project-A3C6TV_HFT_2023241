using A3C6TV_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Tajfun_WPF_Client.ViewModels
{

    class BookingViewModel : ObservableObject, IBooking
    {
        private readonly Booking booking;

        public BookingViewModel(Booking booking)
        {
            this.booking = booking;
        }

        private int year; public int Year
        {
            get { return year; }
            set
            {
                SetProperty(ref year, value);
                StartDate = new DateTime(Year, Month, Day, Starthour, Startminute, 0);
                EndDate = new DateTime(Year, Month, Day, Endhour, Endminute, 0);
            }
        }
        private int month; public int Month
        {
            get { return month; }
            set
            {
                SetProperty(ref month, value); StartDate = new DateTime(Year, Month, Day, Starthour, Startminute, 0);
                EndDate = new DateTime(Year, Month, Day, Endhour, Endminute, 0);
            }
        }
        private int day; public int Day
        {
            get { return day; }
            set
            {
                SetProperty(ref day, value); StartDate = new DateTime(Year, Month, Day, Starthour, Startminute, 0);
                EndDate = new DateTime(Year, Month, Day, Endhour, Endminute, 0);
            }
        }

        private int starthour; public int Starthour
        {
            get { return starthour; }
            set
            {
                SetProperty(ref starthour, value); StartDate = new DateTime(Year, Month, Day, Starthour, Startminute, 0);
            }
        }
        private int startminute; public int Startminute
        {
            get { return startminute; }
            set { SetProperty(ref startminute, value); StartDate = new DateTime(Year, Month, Day, Starthour, Startminute, 0); }
        }

        private int endhour; public int Endhour
        {
            get { return endhour; }
            set { SetProperty(ref endhour, value); EndDate = new DateTime(Year, Month, Day, Endhour, Endminute, 0); }
        }
        private int endminute; public int Endminute
        {
            get { return endminute; }
            set { SetProperty(ref endminute, value); EndDate = new DateTime(Year, Month, Day, Endhour, Endminute, 0); }
        }

        public int BookingId { get => ((IBooking)booking).BookingId; set => ((IBooking)booking).BookingId = value; }
        public Customer Customer { get => ((IBooking)booking).Customer; set => ((IBooking)booking).Customer = value; }
        public int? CustomerId { get => ((IBooking)booking).CustomerId; set => ((IBooking)booking).CustomerId = value; }
        public DateTime EndDate { get => ((IBooking)booking).EndDate; set => ((IBooking)booking).EndDate = value; }
        public PoolTable PoolTable { get => ((IBooking)booking).PoolTable; set => ((IBooking)booking).PoolTable = value; }
        public DateTime StartDate { get => ((IBooking)booking).StartDate; set => ((IBooking)booking).StartDate = value; }
        public int? TableId { get => ((IBooking)booking).TableId; set => ((IBooking)booking).TableId = value; }


    }

    class BookingsViewModel : ObservableRecipient
    {
        private BookingViewModel editedBooking;

        public BookingViewModel EditedBooking
        {
            get { return editedBooking; }
            set { SetProperty(ref editedBooking, value); }
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
                    //selectedBooking = new Booking()
                    //{
                    //    BookingId = value.BookingId,
                    //    TableId = value.TableId,
                    //    PoolTable = value.PoolTable,
                    //    Customer = value.Customer,
                    //    CustomerId = value.CustomerId,
                    //};
                    //Year = value.StartDate.Year;
                    //Month = value.StartDate.Month;
                    //Day = value.StartDate.Day;

                    //Starthour = value.StartDate.Hour;
                    //Startminute = value.StartDate.Minute;
                    //Endhour = value.EndDate.Hour;
                    //Endminute = value.EndDate.Minute;

                    SetProperty(ref selectedBooking, value);

                    IsSomethingSelected = true;

                    //OnPropertyChanged();
                }
                else
                {
                    selectedBooking = new Booking();
                    IsSomethingSelected = false;
                }
                EditedBooking = new BookingViewModel(SelectedBooking.Clone());
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
        public BookingsViewModel()
        {

        }
        public BookingsViewModel(RestCollection<Booking> bookings, RestCollection<Customer> customers, RestCollection<PoolTable> poolTables)
        {
            if (!IsInDesignMode)
            {
                Bookings = bookings;
                Customers = customers;
                PoolTables = poolTables;

                CreateBookingCommand = new RelayCommand(
                    () => Bookings.Add(new Booking().CopyFrom(EditedBooking)
                    ));

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
                        SelectedBooking.CopyFrom(EditedBooking);
                        Bookings.Update(SelectedBooking);
                    },
                    () => IsSomethingSelected == true
                    );
            }
        }
    }
}
