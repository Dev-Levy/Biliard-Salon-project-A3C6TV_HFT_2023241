using A3C6TV_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Windows;

namespace Tajfun_WPF_Client.ViewModels
{
    class PoolTableViewModel : ObservableRecipient
    {
        public RestCollection<PoolTable> PoolTables { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public PoolTableViewModel()
        {

        }

        public PoolTableViewModel(RestCollection<PoolTable> poolTables)
        {
            if (!IsInDesignMode)
            {
                PoolTables = poolTables;
            }
        }
    }
}
