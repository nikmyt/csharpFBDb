using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Core;

namespace WPF.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand PetStocksViewCommand { get; set; }

        //so here we reference xViewModels, but thats not the views. where we got views from?
        public HomeViewModel HomeVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }
        public PetStocksViewModel PetStocksVM { get; set; }

        private object _currentView; //null problemo
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            SettingsVM = new SettingsViewModel();
            PetStocksVM = new PetStocksViewModel();
            
            
            CurrentView = HomeVM;

            //passing object
            HomeViewCommand = new RelayCommand(o =>
            {
            CurrentView = HomeVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
            });
            PetStocksViewCommand = new RelayCommand(o =>
            {
                CurrentView = PetStocksVM;
            });
        }
    }
}
