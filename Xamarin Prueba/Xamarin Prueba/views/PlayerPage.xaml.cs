using System;
using OnlyMusic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Prueba.models;

namespace Xamarin_Prueba.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPage : ContentPage
    {
        public PlayerPage(Estacion estacion)
        {
            InitializeComponent();
            PlayStream(estacion.streamUrl);
            stationLogo.Source = estacion.logo;
        }

        public void PlayStream(string sound)
        {
            DependencyService.Get<IAudio>().load(sound);
        }

        private void play_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IAudio>().Play_Pause();
            if (play.Text == "stop")
            {
                play.Text = "play";
                NavigationPage.SetHasNavigationBar(this, true);
            }
            else
            {
                play.Text = "stop";
                NavigationPage.SetHasNavigationBar(this, false);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}