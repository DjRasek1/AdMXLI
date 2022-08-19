using Android.Content;
using Android.Gms.Ads;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin_Prueba.viewModel;
using Xamarin_Prueba.views;

[assembly: ExportRenderer(typeof(AdsView), typeof(AdsViewRenderer))]
namespace Xamarin_Prueba.viewModel
{
    public class AdsViewRenderer : ViewRenderer<AdsView, AdView>
    {
        public AdsViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdsView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && Control == null)
                SetNativeControl(CreateAdView());

            /*var adView = new AdView(Context);
            adView.AdUnitId = "ca-app-pub-3940256099942544/6300978111";
            var requestBuilder = new AdRequest.Builder();
            adView.LoadAd(requestBuilder.Build());
            SetNativeControl(adView);*/
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(AdView.AdUnitId))
                Control.AdUnitId = Element.AdUnitId;
        }

        private AdView CreateAdView()
        {
            var adView = new AdView(Context)
            {
                AdSize = AdSize.Banner,
                AdUnitId = Element.AdUnitId
            };

            return adView;
        }
    }
}
