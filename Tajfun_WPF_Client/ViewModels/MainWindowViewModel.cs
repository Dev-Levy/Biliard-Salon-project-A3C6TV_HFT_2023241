using A3C6TV_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Tajfun_WPF_Client.Services;

namespace Tajfun_WPF_Client
{
    class MainWindowViewModel : ObservableRecipient
    {
        ICustomerService customerService;
        IBookingService bookingService;
        IPoolTableService poolTableService;

        public RestCollection<Customer> customers { get; set; }
        public RestCollection<Booking> bookings { get; set; }
        public RestCollection<PoolTable> poolTables { get; set; }


        public ICommand GetCustomersCommand { get; set; }
        public ICommand GetBookingsCommand { get; set; }
        public ICommand GetPoolTablesCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                customers = new RestCollection<Customer>("http://localhost:7332/", "Customer", "hub");
                bookings = new RestCollection<Booking>("http://localhost:7332/", "Booking", "hub");
                poolTables = new RestCollection<PoolTable>("http://localhost:7332/", "PoolTable", "hub");


                customerService = Ioc.Default.GetRequiredService<ICustomerService>();
                bookingService = Ioc.Default.GetRequiredService<IBookingService>();
                poolTableService = Ioc.Default.GetRequiredService<IPoolTableService>();

                GetCustomersCommand = new RelayCommand(
                    () => customerService.Open(customers),
                    () => true
                    );
                GetBookingsCommand = new RelayCommand(
                    () => bookingService.Open(bookings, customers, poolTables),
                    () => true
                    );
                GetPoolTablesCommand = new RelayCommand(
                    () => poolTableService.Open(poolTables),
                    () => true
                    );
            }
        }

    }
}
