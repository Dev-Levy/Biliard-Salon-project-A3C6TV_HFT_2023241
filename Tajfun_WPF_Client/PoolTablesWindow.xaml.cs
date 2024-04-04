using A3C6TV_HFT_2023241.Models;
using System.Windows;
using Tajfun_WPF_Client.ViewModels;

namespace Tajfun_WPF_Client
{
    /// <summary>
    /// Interaction logic for PoolTablesWindow.xaml
    /// </summary>
    public partial class PoolTablesWindow : Window
    {
        public PoolTablesWindow(RestCollection<PoolTable> poolTables)
        {
            DataContext = new PoolTableViewModel(poolTables);
            InitializeComponent();
        }
    }
}
