using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Prueba.models;
using Xamarin_Prueba.viewModel;
using System.Collections.Generic;

namespace Xamarin_Prueba.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        #region stream url list
        string urlBestia = "http://stream.radiorama.mx:80/stream/4/stream";
        string urlSuper = "http://stream.radiorama.mx:80/stream/3/stream";
        string urlMexicana = "http://stream.radiorama.mx:80/stream/2/stream";
        string urlVida = "http://stream.radiorama.mx:80/stream/1/stream";
        string urlBuenisima = "http://stream.radiorama.mx:80/stream/7/stream";
        #endregion

        RestService _restService;

        public WelcomePage()
        {

            #region Banners de Clientes

            _restService = new RestService();
            OnLoad();
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            {
                DemoCarouselView.Position = (DemoCarouselView.Position + 1) % indicator.Count;
                Console.WriteLine("La posicion actual del carrusel es: " + DemoCarouselView.Position);
                return true;
            }));
            
            #endregion
        }

        async void OnLoad()
        {
            List<ClientJson> clients = await _restService.GetClientsAsync(
                Constants.EtekClientsEndpoint);
            DemoCarouselView.ItemsSource = clients;
        }

        #region Botones de Estaciones

        private async void ImageButtonBestia_Clicked(object sender, EventArgs e)
        {
            Estacion bestia = new Estacion("Bestia", urlBestia, "LogoBestia.png");
            await Navigation.PushAsync(new PlayerPage(bestia));
        }

        private async void ImageButtonSuper_Clicked(object sender, EventArgs e)
        {
            Estacion super = new Estacion("Super", urlSuper, "LogoSuper.png");
            await Navigation.PushAsync(new PlayerPage(super));
        }

        private async void ImageButtonMexicana_Clicked(object sender, EventArgs e)
        {
            Estacion mexicana = new Estacion("Mexicana", urlMexicana, "LogoMexicana.png");
            await Navigation.PushAsync(new PlayerPage(mexicana));
        }

        private async void ImageButtonVida_Clicked(object sender, EventArgs e)
        {
            Estacion vida = new Estacion("Vida", urlVida, "LogoVida.png");
            await Navigation.PushAsync(new PlayerPage(vida));
        }

        private async void ImageButtonBuenisima_Clicked(object sender, EventArgs e)
        {
            Estacion buenisima = new Estacion("Buenisima", urlBuenisima, "LogoBuenisima.png");
            await Navigation.PushAsync(new PlayerPage(buenisima));
        }

        #endregion
    }
}