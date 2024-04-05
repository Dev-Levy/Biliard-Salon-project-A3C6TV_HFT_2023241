using A3C6TV_HFT_2023241.Models;
using Tajfun_WPF_Client.Services;

namespace Tajfun_WPF_Client
{
    internal class PoolTablesViaWindow : IPoolTableService
    {
        public void Open(RestCollection<PoolTable> poolTables, RestCollection<Booking> bookings)
        {
            new PoolTablesWindow(poolTables, bookings).Show();
        }
    }
}