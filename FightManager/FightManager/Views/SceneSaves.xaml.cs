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
    public partial class SceneSaves : ContentPage
    {
        public SceneSaves(SceneDTO scene)
        {
            InitializeComponent();
            BindingContext = new SceneSavesViewModel(scene);
        }
    }
}