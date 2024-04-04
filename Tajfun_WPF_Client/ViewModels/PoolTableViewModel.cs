using A3C6TV_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Tajfun_WPF_Client.ViewModels
{
    class PoolTableViewModel : ObservableRecipient
    {
        public RestCollection<PoolTable> PoolTables { get; set; }

        private PoolTable selectedPoolTable;

        public PoolTable SelectedPoolTable
        {
            get { return selectedPoolTable; }
            set
            {
                SetProperty(ref selectedPoolTable, value);
                (DeletePoolTableCommand as RelayCommand)?.NotifyCanExecuteChanged();
                (UpdatePoolTableCommand as RelayCommand)?.NotifyCanExecuteChanged();
                (SetTablePoolCommand as RelayCommand)?.NotifyCanExecuteChanged();
                (SetTableSnookerCommand as RelayCommand)?.NotifyCanExecuteChanged();
            }
        }

        public ICommand CreatePoolTableCommand { get; set; }
        public ICommand DeletePoolTableCommand { get; set; }
        public ICommand UpdatePoolTableCommand { get; set; }
        public ICommand SetTablePoolCommand { get; set; }
        public ICommand SetTableSnookerCommand { get; set; }



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
            SelectedPoolTable = new PoolTable();
            if (!IsInDesignMode)
            {
                PoolTables = poolTables;

                CreatePoolTableCommand = new RelayCommand(
                    () => PoolTables.Add(SelectedPoolTable),
                    () => SelectedPoolTable != null
                    );
                DeletePoolTableCommand = new RelayCommand(
                    () => PoolTables.Delete(SelectedPoolTable.TableId),
                    () => SelectedPoolTable != null
                    );
                UpdatePoolTableCommand = new RelayCommand(
                    () => PoolTables.Update(SelectedPoolTable),
                    () => SelectedPoolTable != null
                    );
                SetTablePoolCommand = new RelayCommand(
                    () => SelectedPoolTable.T_kind = "Pool",
                    () => SelectedPoolTable != null && SelectedPoolTable.T_kind != "Pool"
                    );
                SetTableSnookerCommand = new RelayCommand(
                    () => SelectedPoolTable.T_kind = "Snooker",
                    () => SelectedPoolTable != null && SelectedPoolTable.T_kind != "Snooker"
                    );
            }
        }
    }
}
