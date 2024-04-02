using System.Windows;

namespace Tajfun_WPF_Client
{
    /// <summary>
    /// Interaction logic for PoolTables.xaml
    /// </summary>
    public partial class PoolTables : Window
    {
        public PoolTables(RestCollection<PoolTables> poolTables)
        {
            DataContext = poolTables;
            InitializeComponent();
        }
    }
}
