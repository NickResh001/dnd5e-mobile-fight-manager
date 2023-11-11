using FightManager.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FightManager.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        #region Navigation

        public ICommand NavigateToScenes { get; }
        public ICommand NavigateToBestiary { get; }
        public ICommand NavigateToLastBeast { get; }
        public ICommand NavigateToLastSceneSave { get; }
        
        #endregion

        public MainMenuViewModel() 
        {
            NavigateToScenes = new Command((object parameter) => Navigation.PushAsync(new Scenes()));
        }
    }
}
