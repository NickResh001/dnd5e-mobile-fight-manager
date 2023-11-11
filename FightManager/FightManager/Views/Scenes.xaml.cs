using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FightManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Scenes : ContentPage
    {
        public Scenes()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void NavigateBackTo(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
    }
}