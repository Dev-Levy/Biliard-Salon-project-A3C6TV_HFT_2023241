using Tajfun_WPF_Client.Services;

namespace Tajfun_WPF_Client
{
    internal class PoolTablesViaWindow : IPoolTableService
    {
        public void Open(RestCollection<PoolTables> poolTables)
        {
            new PoolTables(poolTables).Show();
        }
    }
}