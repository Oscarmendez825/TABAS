using Android.App;
using Android.OS;
using Android.Widget;
using System.Net;
using AppTabas.APIModels;
using Newtonsoft.Json;
using System;

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
        private Spinner _baggageSpinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set the content view for this activity
            SetContentView(Resource.Layout.activity_bags);

            // Get widgets from layout xml
            _welcomeText = FindViewById<TextView>(Resource.Id.welcomeText);
            _baggageSpinner = FindViewById<Spinner>(Resource.Id.baggageSpinner);

            // Get logged user's info
            _loggedWorkerId = Intent.GetStringExtra("WorkerId");
            using var webClient = new WebClient { BaseAddress = MainActivity.baseAddress };
            var url = "Usuario/Trabajadores/" + _loggedWorkerId;
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            var send = webClient.DownloadString(url);

            _loggedUser = JsonConvert.DeserializeObject<User>(send);
            _welcomeText.Text = "Bienvenid@, " + _loggedUser.Nombre + " " + _loggedUser.Apellido;

            // Manage baggage spinner
            _baggageSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.planets_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _baggageSpinner.Adapter = adapter;

        }

        /// <summary>
        /// Notifies the application when an item has been selected
        /// </summary>
        /// <param name="sender"> Casted to the spinner when its items are selected </param>
        /// <param name="e"></param>
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Short).Show();
        }
    }
}