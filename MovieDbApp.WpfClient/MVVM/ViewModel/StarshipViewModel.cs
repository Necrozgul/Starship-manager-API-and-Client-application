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
    public class StarshipViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Starship> Starships { get; set; }

        private Starship selectedStarship;

        public Starship SelectedStarship
        {
            get { return selectedStarship; }
            set
            {
                if (value != null)
                {
                    selectedStarship = new Starship()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        BrandId = value.BrandId,
                        WeaponId=value.WeaponId,
                        BasePrice = value.BasePrice,
                        
                    };
                    OnPropertyChanged();
                    (DeleteStarshipCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateStarshipCommand { get; set; }

        public ICommand DeleteStarshipCommand { get; set; }

        public ICommand UpdateStarshipCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public StarshipViewModel()
        {
            if (!IsInDesignMode)
            {
                Starships = new RestCollection<Starship>("http://localhost:53910/", "starship", "hub");
                CreateStarshipCommand = new RelayCommand(() =>
                {
                    Starships.Add(new Starship()
                    {
                        Name = SelectedStarship.Name
                    });
                });

                UpdateStarshipCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Starships.Update(SelectedStarship);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                    
                });

                DeleteStarshipCommand = new RelayCommand(() =>
                {
                    Starships.Delete(SelectedStarship.Id);
                },
                () =>
                {
                    return SelectedStarship != null;
                });
                SelectedStarship = new Starship();
            }
            
        }
    }
}
