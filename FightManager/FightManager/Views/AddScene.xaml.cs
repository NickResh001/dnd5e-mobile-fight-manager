using FightManager.DTOs;
using FightManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FightManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddScene : ContentPage
    {
        public AddScene(ScenesViewModel scenesVM)
        {
            InitializeComponent();
            BindingContext = new AddSceneViewModel(scenesVM);
        }
    }
}