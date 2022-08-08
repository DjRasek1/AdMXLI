using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Xamarin_Prueba.viewModel
{
    public class ClientViewModel
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
    }
}