using System;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace Xamarin_Prueba.models
{
    public class ClientJson
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("site")]
        public string Site { get; set; }

        public Command TapCommand { get; set; }

        public EventHandler TapClickEventHandler;

        public ClientJson()
        {
            TapCommand = new Command(() => OnImageClicked());
        }

        public void OnImageClicked()
        {
            TapClickEventHandler?.Invoke(this, EventArgs.Empty);
        }
    }
}
