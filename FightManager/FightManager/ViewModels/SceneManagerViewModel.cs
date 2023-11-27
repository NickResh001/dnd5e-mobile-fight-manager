using FightManager.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FightManager.ViewModels
{
    public class SceneManagerViewModel : ViewModelBase
    {
        public ICommand NavigateBackTo { get; }
        public ICommand NavigateToModalSceneMenu { get; }
        public ICommand NavigateToFlyoutMenu { get; }
        public SceneManagerViewModel()
        {
            NavigateBackTo = new Command(() => { Navigation.PopAsync(); });
            NavigateToModalSceneMenu = new Command(() => { Navigation.PushModalAsync(new ModalSceneMenu()); });
            NavigateToFlyoutMenu = new Command(() => { Navigation.PushModalAsync(new FlyoutSceneMenu(), false); });
        }
    }
}
