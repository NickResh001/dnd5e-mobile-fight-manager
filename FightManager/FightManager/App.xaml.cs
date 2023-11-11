using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FightManager.Views;
using FightManager.ViewModels;

namespace FightManager
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainMenu());
            ViewModelBase.Navigation = MainPage.Navigation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
