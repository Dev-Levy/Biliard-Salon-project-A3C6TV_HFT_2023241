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
        public bool IsSomethingSelected { get; set; } = false;
        public RestCollection<PoolTable> PoolTables { get; set; }
        public RestCollection<Booking> Bookings { get; set; }

        private PoolTable selectedPoolTable;

        public PoolTable SelectedPoolTable
        {
            get { return selectedPoolTable; }
            set
            {
                if (value != null)
                {
                    selectedPoolTable = new PoolTable()
                    {
                        TableId = value.TableId,
                        T_kind = value.T_kind
                    };
                    IsSomethingSelected = true;
                    OnPropertyChanged();
                }
                else
                {
                    SelectedPoolTable = new PoolTable();
                    IsSomethingSelected = false;
                }
                (DeletePoolTableCommand as RelayCommand)?.NotifyCanExecuteChanged();
                (SetTablePoolCommand as RelayCommand)?.NotifyCanExecuteChanged();
                (SetTableSnookerCommand as RelayCommand)?.NotifyCanExecuteChanged();

            }
        }

        public ICommand CreatePoolCommand { get; set; }
        public ICommand CreateSnookerCommand { get; set; }
        public ICommand DeletePoolTableCommand { get; set; }
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
        public PoolTableViewModel(RestCollection<PoolTable> poolTables, RestCollection<Booking> bookings)
        {
            if (!IsInDesignMode)
            {
                PoolTables = poolTables;
                Bookings = bookings;


                CreatePoolCommand = new RelayCommand(
                    () => PoolTables.Add(new PoolTable()
                    {
                        T_kind = "Pool"
                    }));

                CreateSnookerCommand = new RelayCommand(
                    () => PoolTables.Add(new PoolTable()
                    {
                        T_kind = "Snooker"
                    }));

                DeletePoolTableCommand = new RelayCommand(
                    async () =>
                    {
                        //foreach (var bking in Bookings)
                        //{
                        //    if (bking.TableId == SelectedPoolTable.TableId)
                        //        Bookings.Delete(bking.BookingId);
                        //}
                        PoolTables.Delete(SelectedPoolTable.TableId);
                        await Bookings.Refresh();
                        IsSomethingSelected = false;
                    },
                    () => IsSomethingSelected == true
                    );


                SetTablePoolCommand = new RelayCommand(
                    () =>
                    {
                        SelectedPoolTable.T_kind = "Pool";
                        PoolTables.Update(SelectedPoolTable);
                        IsSomethingSelected = false;
                    },
                    () => IsSomethingSelected == true && SelectedPoolTable.T_kind != "Pool"
                    );
                SetTableSnookerCommand = new RelayCommand(
                    () =>
                    {
                        SelectedPoolTable.T_kind = "Snooker";
                        PoolTables.Update(SelectedPoolTable);
                        IsSomethingSelected = false;
                    },
                    () => IsSomethingSelected == true && SelectedPoolTable.T_kind != "Snooker"
                    );
            }
        }
    }
}
