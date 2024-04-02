using A3C6TV_HFT_2023241.Models;
using System.Windows;
using Tajfun_WPF_Client.ViewModels;

namespace Tajfun_WPF_Client
{
    /// <summary>
    /// Interaction logic for PoolTables.xaml
    /// </summary>
    public partial class PoolTables : Window
    {
        public PoolTables(RestCollection<PoolTable> poolTables)
        {
            DataContext = new PoolTableViewModel(poolTables);
            InitializeComponent();
        }
    }
}
