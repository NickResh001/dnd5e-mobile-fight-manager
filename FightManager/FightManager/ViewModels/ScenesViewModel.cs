using FightManager.DTOs;
using FightManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FightManager.ViewModels
{
    public class ScenesViewModel : ViewModelBase
    {
		public ObservableCollection<SceneDTO> Scenes
		{
			get
			{
				return _scenes;
			}
			set
			{
                _scenes = value;
				OnPropertyChanged(nameof(Scenes));
			}
		}
        private ObservableCollection<SceneDTO> _scenes;
		public ObservableCollection<SettingDTO> Settings
		{
			get
			{
				return _settings;
			}
			set
			{
				_settings = value;
				OnPropertyChanged(nameof(Settings));
			}
		}
        private ObservableCollection<SettingDTO> _settings;

        public ICommand NavigateBackToMainMenu { get; }
        public ICommand NavigateToAddScene { get; }
		public ICommand NavigateToSceneSaves { get; }
        public ScenesViewModel()
        {
            NavigateBackToMainMenu = new Command((object parameter) => Navigation.PopAsync());
            NavigateToAddScene = new Command(() => Navigation.PushModalAsync(new AddScene(this)));
			NavigateToSceneSaves = new Command(NavToSceneSaves);

			HardcodeInit();
        }

		private void NavToSceneSaves(object parameter)
		{
			var scene = parameter as SceneDTO;
			if (scene != null)
            {
                Navigation.PushAsync(new SceneSaves(scene));
            }
		}

		public void HardcodeInit()
		{
			_settings = new ObservableCollection<SettingDTO>();
			_scenes = new ObservableCollection<SceneDTO>();

			Settings.Add(new SettingDTO(0, "Эбберон"));
			Settings.Add(new SettingDTO(1, "Забытые королевства"));

            Scenes.Add(new SceneDTO(0, "Таинсвенная Хижина", Settings[0]));
			Scenes.Add(new SceneDTO(1, "Таинсвенный Замок", Settings[1]));
			Scenes.Add(new SceneDTO(2, "Волчий бурьян", Settings[1]));
        }
    }
}
