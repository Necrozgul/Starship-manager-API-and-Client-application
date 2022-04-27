using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Brand> Brands { get; set; }

        private Brand selectedBrand;

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        
                    };
                    OnPropertyChanged();
                    (DeleteActorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateActorCommand { get; set; }

        public ICommand DeleteActorCommand { get; set; }

        public ICommand UpdateActorCommand { get; set; }

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
                Brands = new RestCollection<Brand>("http://localhost:53910/", "brand", "hub");
                CreateActorCommand = new RelayCommand(() =>
                {
                    Brands.Add(new Brand()
                    {
                        Name = SelectedBrand.Name
                    });
                });

                UpdateActorCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Brands.Update(SelectedBrand);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                    
                });

                DeleteActorCommand = new RelayCommand(() =>
                {
                    Brands.Delete(SelectedBrand.Id);
                },
                () =>
                {
                    return SelectedBrand != null;
                });
                SelectedBrand = new Brand();
            }
            
        }
    }
}
