using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin_Prueba.models;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace Xamarin_Prueba.viewModel
{
    public class RestService
    {
        List<ClientJson> clients;
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();

            if (Device.RuntimePlatform == Device.UWP)
            {
                _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            }
        }

        public async Task<List<ClientJson>> GetClientsAsync(string uri)
        {
            clients = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    clients = JsonConvert.DeserializeObject<List<ClientJson>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return clients;
        }

        int taps = 0;

        void OnTapped(object sender, EventArgs e)
        {
            taps++;
            var img = (ClientJson)sender;
            Browser.OpenAsync(img.Site, BrowserLaunchMode.SystemPreferred);
            Debug.WriteLine($"tapped: {taps} {img.Name}");
        }
    }
}