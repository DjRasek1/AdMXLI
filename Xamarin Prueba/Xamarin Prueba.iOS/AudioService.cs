using OnlyMusic.iOS;
using AVFoundation;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]
namespace OnlyMusic.iOS
{
    public class AudioService : IAudio
    {
        int clicks = 0;

        public AudioService() { }
        AVPlayer player;
        public bool Play_Pause()
        {
            if (clicks % 2 != 0)
            {
                this.player.Pause();
                clicks++;

            }
            else
            {
                this.player.Play();
                clicks++;
            }
            return true;

        }

        public bool Stop()
        {
            if (player != null)
            {
                player.Dispose();
                clicks = 0;
            }
            return true;
        }

        public bool load(string url)
        {
            if (clicks == 0)
            {
                this.player = new AVPlayer();
                this.player = AVPlayer.FromUrl(NSUrl.FromString(url));
                this.player.Play();
                clicks++;
            }
            return true;
        }
    }

}