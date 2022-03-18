using Android.App;
using Android.OS;
using Android.Widget;
using System.Net;
using AppTabas.APIModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
        private Spinner _bagCartSpinner;
        private Button _btnScan;
        private Button _btnAssign;
        private List<Bag> _bagList;
        private List<BagCart> bagCartList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set the content view for this activity
            SetContentView(Resource.Layout.activity_bags);

            // Get widgets from layout xml
            _welcomeText = FindViewById<TextView>(Resource.Id.welcomeText);
            _baggageSpinner = FindViewById<Spinner>(Resource.Id.baggageSpinner);
            _bagCartSpinner = FindViewById<Spinner>(Resource.Id.bagcartSpinner);
            _btnScan = FindViewById<Button>(Resource.Id.btnScan);
            _btnAssign = FindViewById<Button>(Resource.Id.btnAssign);

            // Get logged user's info
            _loggedWorkerId = Intent.GetStringExtra("WorkerId");
            using var webClient = new WebClient { BaseAddress = MainActivity.baseAddress };
            var url = "Usuario/Trabajadores/" + _loggedWorkerId;
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            var send = webClient.DownloadString(url);

            _loggedUser = JsonConvert.DeserializeObject<User>(send);
            _welcomeText.Text = _loggedUser.Nombre + " " + _loggedUser.Apellido;


            // Manage baggage spinner
            url = "Maleta/Maletas";
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            send = webClient.DownloadString(url);

            _bagList = JsonConvert.DeserializeObject<List<Bag>>(send);
            List<string> bagIdList = new List<string>();

            // Manage bagcart spinner
            url = "BagCart/Bagcarts";
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            send = webClient.DownloadString(url);

            bagCartList = JsonConvert.DeserializeObject<List<BagCart>>(send);
            List<string> bagCartIdList = new List<string>();

            foreach (Bag bag in _bagList)
            {
                // Show bag to worker only if it hasn't been assigned to a bagcart yet
                if (bag.bagcartId == 0)
                {
                    bagIdList.Add("Maleta #" + bag.numero_maleta.ToString());
                }
            };

            foreach (BagCart bagCart in bagCartList)
            {
                bagCartIdList.Add("BagCart #" + bagCart.identificador_BC.ToString());
            }

            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, bagIdList);
            _baggageSpinner.Adapter = adapter;

            var adapter2 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, bagCartIdList);
            _bagCartSpinner.Adapter = adapter2;

            // Manage buttons
            _btnScan.Click += (sender, args) =>
            {
                scanBag();
            };

            _btnAssign.Click += (sender, args) =>
            {
                assignBagCart();
            };
            

        }

        /// <summary>
        /// Shows the selected bag's scan status when the button is tapped
        /// </summary>
        private void scanBag()
        {
            string toastText;
            string selected = _baggageSpinner.SelectedItem.ToString();
            selected = selected.Remove(0, 8); //Remove unnecessary text

            foreach (Bag bag in _bagList)
            {
                if (bag.numero_maleta == Int32.Parse(selected))
                {
                    if (bag.aceptada)
                    {
                        toastText = "La maleta ha pasado el escaneo satisfactoriamente";
                    }
                    else
                    {
                        toastText = "La maleta ha sido rechazada por el escaneo";
                    }
                    Toast.MakeText(this, toastText, ToastLength.Short).Show();
                }
            }
        }

        /// <summary>
        /// Assigns the selected bagcart to the selected bag
        /// </summary>
        private void assignBagCart()
        {
            string selectedBag = _baggageSpinner.SelectedItem.ToString().Remove(0, 8);
            string selectedBagCart = _bagCartSpinner.SelectedItem.ToString().Remove(0, 9);

            Bag newBag = new Bag(Int32.Parse(selectedBag), Int32.Parse(selectedBagCart), _loggedUser.Cedula);
            var bagJson = JsonConvert.SerializeObject(newBag);

            using var webClient = new WebClient { BaseAddress = MainActivity.baseAddress };
            var url = "Maleta/AsignarBCMaleta";
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            var send = webClient.UploadString(url, bagJson);

            Toast.MakeText(this, "BagCart asignado satisfactoriamente", ToastLength.Short).Show();
        }
    }
}