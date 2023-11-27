using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FightManager.ViewModels
{
    public class FlyoutSceneMenuViewModel : ViewModelBase
    {
        public ICommand NavigateBackTo { get; }
        public ICommand ToSaves { get; }
        public ICommand ToScenes { get; }
        public ICommand ToMainMenu { get;  }
        public FlyoutSceneMenuViewModel()
        {
            NavigateBackTo = new Command(() => { Navigation.PopModalAsync(false); }); 
        }
    }
}
