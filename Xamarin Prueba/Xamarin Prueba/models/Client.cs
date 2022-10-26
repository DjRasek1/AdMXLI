using System;
using Xamarin.Forms;

public class ClientObject
{
    public Client[] Clients { get; set; }
}

public class Client
{
    public string Name { get; set; }
    public string Image { get; set; }
    public string Site { get; set; }
    public Command TapCommand { get; set; }

    public EventHandler TapClickEventHandler;

    public Client()
    {
        TapCommand = new Command(() => OnImageClicked());
    }

    public void OnImageClicked()
    {
        TapClickEventHandler?.Invoke(this, EventArgs.Empty);
    }
}
