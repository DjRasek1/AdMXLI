using OnlyMusic;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Xamarin.Forms;
using LifeImprovementCommunity.Droid;
using Android.Media;

[assembly: Dependency(typeof(AudioSerivce))]
namespace LifeImprovementCommunity.Droid
{
    public class AudioSerivce : AppCompatActivity, IAudio, MediaPlayer.IOnPreparedListener, MediaPlayer.IOnErrorListener
    {
        int clicks = 0; 
        MediaPlayer player;

        public AudioSerivce()
        {
        }

        public bool OnError(MediaPlayer mp, [GeneratedEnum] MediaError what, int extra)
        {
            mp.Reset();
            return false;
        }

        public void OnPrepared(MediaPlayer mp)
        {
            mp.Start();
        }

        public bool load(string url)
        {
            clicks = 0;
            if (clicks == 0)
            {
                System.Console.WriteLine("This is the first click " + clicks.ToString());
                this.player = new MediaPlayer();
                this.player.SetDataSource(url);
                this.player.SetOnPreparedListener(this);
                this.player.PrepareAsync();

        clicks++;
            }
            return true;
        }

        public bool Stop()
        {
            System.Console.WriteLine("this was the stop button " + clicks.ToString());
            this.player.Stop();
            clicks = 0;
            return true;
        }

        public bool Play_Pause()
        {
            if (clicks % 2 != 0)
            {
                System.Console.WriteLine("This is for make a stop " + clicks.ToString());
                this.player.Stop();
                clicks++;
            }
            else
            {
                System.Console.WriteLine("This is for make a replay " + clicks.ToString());
                this.player.PrepareAsync();
                clicks++;
            }
            return true;
        }
    }
}