using A3C6TV_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;

namespace Tajfun_WPF_Client.ViewModels
{
    internal class PoolTableViewModel
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

        public PoolTableViewModel(RestCollection<PoolTable> poolTables)
        {
            if (!IsInDesignMode)
            {
                PoolTables = poolTables;
            }
        }
    }
}
