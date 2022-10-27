using System;
using System.Diagnostics;
using Xamarin.Essentials;
using System.Collections.ObjectModel;

namespace Xamarin_Prueba.viewModel
{
    /*public class ClientViewModel
    {
        private string _name;
        private string _image;
        private string _site; 

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }
        public string Site
        {
            get
            {
                return _site;
            }
            set
            {
                _site = value;
            }
        }

        public async Task GetClientsAsync(string url, ClientObject someClients)
        {
            var item = new HttpClient();
            item.BaseAddress = new Uri(url);
            var response = await item.GetAsync(item.BaseAddress);
            response.EnsureSuccessStatusCode();
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            someClients = JsonConvert.DeserializeObject<ClientObject>(jsonResult);
        }

        private void setValue(Client clients)
        {
            var clientName = clients.Name;
            var clientImage = clients.Image;
            var clientSite = clients.Site;

            Name = clientName;
            Image = clientImage;
            Site = clientSite;
        }
    }*/

    public class ClientViewModel
    {
        public ObservableCollection<Client> Clients { get; set; }

        public ClientViewModel()
        {
            #region Objeto Clientes Funcional Comentado
            
            Clients = new ObservableCollection<Client>
            {
                new Client
                {
                    Name  = "e-Tek",
                    Image = "https://www.e-tek.com.mx/clients/e-tek.png",
                    Site  = "https://www.e-tek.com.mx",
                    TapClickEventHandler = OnTapped 
                },
                new Client
                {
                    Name  = "Caprichos",
                    Image = "https://www.e-tek.com.mx/clients/calm.png",
                    Site  = "https://www.facebook.com/thecalmsalon",
                    TapClickEventHandler = OnTapped
                }
            };
            
            #endregion
        }

        int taps = 0;

        void OnTapped(object sender, EventArgs e)
        {
            taps++;
            var img = (Client)sender;
            Browser.OpenAsync(img.Site, BrowserLaunchMode.SystemPreferred);
            Debug.WriteLine($"tapped: {taps} {img.Name}");
        }
    }
}