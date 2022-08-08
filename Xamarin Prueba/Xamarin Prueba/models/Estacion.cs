namespace Xamarin_Prueba.models
{
    public class Estacion
    {
        public string estacion;

        public string streamUrl;

        public string logo;

        public Estacion(string estacion, string streamUrl, string logo)
        {
            this.estacion = estacion;
            this.streamUrl = streamUrl;
            this.logo = logo;
        }
    }
}
