using FightManager.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FightManager.ViewModels
{
    public class AddSceneViewModel : ViewModelBase
    {
        public ICommand NavigateBackTo { get; set; }
        public ScenesViewModel scenesVM { get; set; }
        public string CurrentSceneName
        {
            get
            {
                return currentSceneName;
            }
            set
            {
                currentSceneName = value;
                OnPropertyChanged(nameof(CurrentSceneName));
            }
        }
        private string currentSceneName;
        public SettingDTO CurrentSceneSetting
        {
            get
            {
                return currentSceneSetting;
            }
            set
            {
                currentSceneSetting = value;
                OnPropertyChanged(nameof(CurrentSceneSetting));
            }
        }
        private SettingDTO currentSceneSetting;
        
        public ObservableCollection<SettingDTO> Settings => scenesVM.Settings;

        public AddSceneViewModel(ScenesViewModel scenesVM)
        {
            this.scenesVM = scenesVM;
            NavigateBackTo = new Command((object parameter) => Navigation.PopModalAsync());
        }
    }
}
