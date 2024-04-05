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
        public bool IsSomethingSelected { get; set; } = false;
        public RestCollection<Customer> Customers { get; set; }
        public RestCollection<Booking> Bookings { get; set; }

        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (value != null)
                {
                    selectedCustomer = new Customer()
                    {
                        CustomerId = value.CustomerId,
                        Name = value.Name,
                        Email = value.Email,
                        Phone = value.Phone
                    };
                    IsSomethingSelected = true;
                    OnPropertyChanged();
                }
                else
                {
                    selectedCustomer = new Customer();
                    IsSomethingSelected = false;
                }
                (DeleteCustomerCommand as RelayCommand)?.NotifyCanExecuteChanged();
                (UpdateCustomerCommand as RelayCommand)?.NotifyCanExecuteChanged();
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
        public CustomerViewModel(RestCollection<Customer> customers, RestCollection<Booking> bookings)
        {
            if (!IsInDesignMode)
            {
                Customers = customers;
                Bookings = bookings;

                CreateCustomerCommand = new RelayCommand(
                    () => Customers.Add(new Customer()
                    {
                        Name = selectedCustomer.Name, //lehet üres minden mező
                        Email = selectedCustomer.Email,
                        Phone = selectedCustomer.Phone
                    }));

                DeleteCustomerCommand = new RelayCommand(
                    () =>
                    {
                        foreach (var bking in Bookings)
                        {
                            if (bking.CustomerId == SelectedCustomer.CustomerId)
                                Bookings.Delete(bking.BookingId);
                        }
                        Customers.Delete(SelectedCustomer.CustomerId);
                        IsSomethingSelected = false;
                    },
                    () => IsSomethingSelected == true
                    );

                UpdateCustomerCommand = new RelayCommand(
                    () => Customers.Update(SelectedCustomer),
                    () => IsSomethingSelected == true
                    );
            }

        }
    }
}
