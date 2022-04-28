using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.WpfClient.MVVM.ViewModel
{
    public class WeaponViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Weapon> Weapons { get; set; }

        private Weapon selectedWeapon;

        public Weapon SelectedWeapon
        {
            get { return selectedWeapon; }
            set
            {
                if (value != null)
                {
                    selectedWeapon = new Weapon()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        
                    };
                    OnPropertyChanged();
                    (DeleteWeaponCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateWeaponCommand { get; set; }

        public ICommand DeleteWeaponCommand { get; set; }

        public ICommand UpdateWeaponCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public WeaponViewModel()
        {
            if (!IsInDesignMode)
            {
                Weapons = new RestCollection<Weapon>("http://localhost:53910/", "weapon", "hub");
                CreateWeaponCommand = new RelayCommand(() =>
                {
                    Weapons.Add(new Weapon()
                    {
                        Name = SelectedWeapon.Name,
                        Starships = SelectedWeapon.Starships,
                        
                    });
                });

                UpdateWeaponCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Weapons.Update(SelectedWeapon);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                    
                });

                DeleteWeaponCommand = new RelayCommand(() =>
                {
                    Weapons.Delete(SelectedWeapon.Id);
                },
                () =>
                {
                    return SelectedWeapon != null;
                });
                SelectedWeapon = new Weapon();
            }
            
        }
    }
}
