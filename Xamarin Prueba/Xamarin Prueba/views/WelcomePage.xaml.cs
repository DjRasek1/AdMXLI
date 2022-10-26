using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Prueba.models;
using Xamarin_Prueba.viewModel;
using System.Collections.ObjectModel;

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


        public ObservableCollection<Client> Clients { get; set; }

        public WelcomePage()
        {
            #region Banners de Clientes

            InitializeComponent();

            Clients = new ClientViewModel().Clients;
            BindingContext = new ClientViewModel();

            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            {
                DemoCarouselView.Position = (DemoCarouselView.Position + 1) % Clients.Count;
                return true;
            }));

            #endregion
        }

        /*public async void callJson(ClientObject co)
        {
            var url = "http://www.e-tek.com.mx/clients/clients.json";
            await clientView.GetClientsAsync(url, co);
        }*/
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