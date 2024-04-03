using A3C6TV_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Tajfun_WPF_Client.ViewModels
{
    class CustomerViewModel : ObservableRecipient
    {
        public RestCollection<Customer> Customers { get; set; }

        private Customer selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (value != null)
                {
                    selectedCustomer = new Customer() //ez egy gány megoldás szerintem
                    {
                        Name = value.Name,
                        Email = value.Email,
                        Phone = value.Phone,
                        CustomerId = value.CustomerId
                    };
                    OnPropertyChanged();

                    //SetProperty(ref selectedCustomer, value); //ez lenne helyette, de hibás az update

                    (DeleteCustomerCommand as RelayCommand)?.NotifyCanExecuteChanged();
                    (UpdateCustomerCommand as RelayCommand)?.NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public ICommand UpdateCustomerCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public CustomerViewModel()
        {

        }
        public CustomerViewModel(RestCollection<Customer> customers)
        {
            SelectedCustomer = new Customer();
            if (!IsInDesignMode)
            {
                Customers = customers;

                CreateCustomerCommand = new RelayCommand(
                    () => Customers.Add(new Customer()
                    {
                        Name = selectedCustomer.Name, //lehet üres minden mező
                        Email = selectedCustomer.Email,
                        Phone = selectedCustomer.Phone
                    }),
                    () => true
                    );

                DeleteCustomerCommand = new RelayCommand(
                    () => Customers.Delete(SelectedCustomer.CustomerId),
                    () => SelectedCustomer != null
                    );

                UpdateCustomerCommand = new RelayCommand(
                    () => Customers.Update(SelectedCustomer),
                    () => SelectedCustomer != null
                    );
            }

        }
    }
}
