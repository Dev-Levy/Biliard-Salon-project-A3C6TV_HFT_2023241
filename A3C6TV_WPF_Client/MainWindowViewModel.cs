﻿using A3C6TV_HFT_2023241.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace A3C6TV_WPF_Client
{
    public class MainWindowViewModel : ObservableRecipient
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
                    selectedCustomer = new Customer()
                    {
                        Name = value.Name,
                        CustomerId = value.CustomerId,
                    };
                    OnPropertyChanged();
                    (DeleteCustomerCommand as RelayCommand).NotifyCanExecuteChanged();
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

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Customers = new RestCollection<Customer>("http://localhost:7332/", "customer", "hub");

                CreateCustomerCommand = new RelayCommand(() =>
                {
                    Customers.Add(new Customer() { Name = SelectedCustomer.Name });
                });

                DeleteCustomerCommand = new RelayCommand(() =>
                {
                    Customers.Delete(SelectedCustomer.CustomerId);
                },
                () =>
                {
                    return SelectedCustomer != null;
                });

                UpdateCustomerCommand = new RelayCommand(() =>
                {
                    Customers.Update(SelectedCustomer);
                });
            }
            SelectedCustomer = new Customer();
        }
    }
}