using Tajfun_WPF_Client.Services;

namespace Tajfun_WPF_Client
{
    internal class PoolTablesViaWindow : IPoolTableService
    {
        public void Open()
        {
            new PoolTables().Show();
        }
    }
}