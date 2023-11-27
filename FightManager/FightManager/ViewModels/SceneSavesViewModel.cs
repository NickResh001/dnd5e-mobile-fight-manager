using FightManager.DTOs;
using FightManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime;
using System.Text;
using System.Windows.Input;
using System.Xml.Schema;
using Xamarin.Forms;

namespace FightManager.ViewModels
{
    public class SceneSavesViewModel : ViewModelBase
    {
        public ObservableCollection<SceneSaveDTO> SceneSaves
        {
            get
            {
                return _sceneSaves;
            }
            set
            {
                _sceneSaves = value;
                OnPropertyChanged(nameof(SceneSaves));
            }
        }
        private ObservableCollection<SceneSaveDTO> _sceneSaves;
        
		public SceneDTO CurrentScene
		{
			get
			{
				return _cuurentScene;
			}
			set
			{
				_cuurentScene = value;
				OnPropertyChanged(nameof(CurrentScene));
			}
		}
        private SceneDTO _cuurentScene;

        public ICommand NavigateBackTo { get; }
        public ICommand NavigateToSave { get; }
        public SceneSavesViewModel(SceneDTO scene)
		{
            CurrentScene = scene;

            NavigateBackTo = new Command(() => { Navigation.PopAsync(); });
            NavigateToSave = new Command(() => { Navigation.PushAsync(new SceneManager()); });

            HardcodeInit();
		}

        public void HardcodeInit()
        {
            _sceneSaves = new ObservableCollection<SceneSaveDTO>();

            SceneSaves.Add(new SceneSaveDTO(0, DateTime.Today, CurrentScene.Title + "1", CurrentScene, 0));
            SceneSaves.Add(new SceneSaveDTO(1, DateTime.Now, CurrentScene.Title + "2", CurrentScene, 0));
            SceneSaves.Add(new SceneSaveDTO(2, DateTime.Now, CurrentScene.Title + "3", CurrentScene, 0));
            SceneSaves.Add(new SceneSaveDTO(3, DateTime.Now, CurrentScene.Title + "4", CurrentScene, 0));
            SceneSaves.Add(new SceneSaveDTO(4, DateTime.Now, "Другое название", CurrentScene, 0));
        }
    }
}
