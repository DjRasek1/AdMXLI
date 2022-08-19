using Xamarin.Forms;

namespace Xamarin_Prueba.views
{
    public class AdsView : View
    {
        public static readonly BindableProperty AdUnitIdProperty = BindableProperty.Create(
            nameof(AdUnitId), typeof(string),
            typeof(AdsView), string.Empty);

        public string AdUnitId
        {
            get => (string)GetValue(AdUnitIdProperty);
            set => SetValue(AdUnitIdProperty, value);
        }
    }
}
