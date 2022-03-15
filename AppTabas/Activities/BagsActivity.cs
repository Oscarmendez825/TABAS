using Android.App;
using Android.OS;
using Android.Widget;
using System.Net;
using AppTabas.APIModels;
using Newtonsoft.Json;

namespace AppTabas.Activities
{
    /// <summary>
    /// This class represents the main app page/layout where workers
    /// scan and assign baggage to the bagcarts.
    /// It inherits from the base class for Android activities
    /// </summary>
    [Activity(Label = "BagsActivity")]
    public class BagsActivity : Activity
    {
        private string _loggedWorkerId;
        private User _loggedUser;
        private TextView _welcomeText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set the content view for this activity
            SetContentView(Resource.Layout.activity_bags);

            _welcomeText = FindViewById<TextView>(Resource.Id.welcomeText);

            // Get logged user's info
            _loggedWorkerId = Intent.GetStringExtra("WorkerId");
            using var webClient = new WebClient { BaseAddress = MainActivity.baseAddress };
            var url = "Usuario/Trabajadores/" + _loggedWorkerId;
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            var send = webClient.DownloadString(url);

            _loggedUser = JsonConvert.DeserializeObject<User>(send);
            _welcomeText.Text = "Bienvenid@, " + _loggedUser.Nombre + " " + _loggedUser.Apellido;

        }
    }
}