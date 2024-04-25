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

        private int selectedBookingIndex;
        public int SelectedBookingIndex
        {
            get { return selectedBookingIndex; }
            set { SetProperty(ref selectedBookingIndex, value); }
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
        public BookingViewModel(RestCollection<Booking> bookings, RestCollection<Customer> customers, RestCollection<PoolTable> poolTables)
        {
            selectedBooking = new Booking();
            selectedBooking.Customer = new Customer();
            selectedBooking.PoolTable = new PoolTable();

            bookings.SetupActionAfterInit(() => SelectedBookingIndex = 0);

            if (!IsInDesignMode)
            {
                Bookings = bookings;
                Customers = customers;
                PoolTables = poolTables;

                CreateBookingCommand = new RelayCommand(
                    () =>
                    {
                        try
                        {
                            Bookings.Add(new Booking()
                            {
                                StartDate = new DateTime(Year, Month, Day, Starthour, Startminute, 0),
                                EndDate = new DateTime(Year, Month, Day, Endhour, Endminute, 0),
                                CustomerId = SelectedBooking.Customer.CustomerId,
                                TableId = SelectedBooking.PoolTable.TableId
                            });
                        }
                        catch (Exception e) { }
                    });

                DeleteBookingCommand = new RelayCommand(
                    async () =>
                    {
                        try
                        {
                            await Bookings.Delete(SelectedBooking.BookingId);
                            IsSomethingSelected = false;
                            //SelectedBookingIndex = 0;
                        }
                        catch (Exception e) { }
                    },
                    () => IsSomethingSelected == true
                    );


                UpdateBookingCommand = new RelayCommand(
                    () =>
                    {
                        SelectedBooking.StartDate = new DateTime(Year, Month, Day, Starthour, Startminute, 0);
                        SelectedBooking.EndDate = new DateTime(Year, Month, Day, Endhour, Endminute, 0);
                        SelectedBooking.CustomerId = SelectedBooking.Customer.CustomerId;
                        SelectedBooking.TableId = SelectedBooking.PoolTable.TableId;
                        Bookings.Update(SelectedBooking);
                    },
                    () => IsSomethingSelected == true
                    );
            }
        }
    }
}
