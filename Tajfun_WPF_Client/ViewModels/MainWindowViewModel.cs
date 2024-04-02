using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Tajfun_WPF_Client.Services;

namespace Tajfun_WPF_Client.ViewModels
{
    class MainWindowViewModel : ObservableRecipient
    {
        ICustomerService customerService;
        IBookingService bookingService;
        IPoolTableService poolTableService;

        public RestCollection<Customers> customers { get; set; }
        public RestCollection<Bookings> bookings { get; set; }
        public RestCollection<PoolTables> poolTables { get; set; }


        ICommand GetCustomersCommand;
        ICommand GetBookingsCommand;
        ICommand GetPoolTablesCommand;

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
                customers = new RestCollection<Customers>("http://localhost:7332/", "customer", "hub");
                bookings = new RestCollection<Bookings>("http://localhost:7332/", "booking", "hub");
                poolTables = new RestCollection<PoolTables>("http://localhost:7332/", "pooltable", "hub");


                customerService = Ioc.Default.GetRequiredService<ICustomerService>();
                bookingService = Ioc.Default.GetRequiredService<IBookingService>();
                poolTableService = Ioc.Default.GetRequiredService<IPoolTableService>();

                GetCustomersCommand = new RelayCommand(
                    () => customerService.Open(customers),
                    () => true
                    );
                GetBookingsCommand = new RelayCommand(
                    () => bookingService.Open(bookings),
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
