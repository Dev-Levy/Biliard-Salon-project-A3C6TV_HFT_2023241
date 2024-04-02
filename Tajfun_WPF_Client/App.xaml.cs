using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Tajfun_WPF_Client.Services;

namespace Tajfun_WPF_Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                    .AddSingleton<ICustomerService, CustomersViaWindow>()
                    .AddSingleton<IBookingService, BookingsViaWindow>()
                    .AddSingleton<IPoolTableService, PoolTablesViaWindow>()
                    .BuildServiceProvider()
                    );
        }
    }

}
