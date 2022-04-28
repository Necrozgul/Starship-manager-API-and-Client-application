using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using ZNJXL9_HFT_2021221.Models;
using ZNJXL9_HFT_2021221.WpfClient.MVVM.View;

namespace ZNJXL9_HFT_2021221.WpfClient.MVVM.ViewModel
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public ICommand OpenBrandWindowCommand { get; set; }

        public ICommand OpenStarshipWindowCommand { get; set; }

        public ICommand OpenWeaponWindowCommand { get; set; }

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
                OpenBrandWindowCommand = new RelayCommand(() =>
                {
                    BrandWindow bradWindow = new BrandWindow();
                    bradWindow.Show();
                });

                OpenStarshipWindowCommand = new RelayCommand(() =>
                {
                    StarshipWindow starshipWindow = new StarshipWindow();
                    starshipWindow.Show();
                });

                OpenWeaponWindowCommand = new RelayCommand(() =>
                {
                    WeaponWindow weaponWindow = new WeaponWindow();
                    weaponWindow.Show();
                });
            }
            
        }
    }
}
