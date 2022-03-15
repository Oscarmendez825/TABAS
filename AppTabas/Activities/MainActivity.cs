using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Newtonsoft.Json;
using AppTabas.APIModels;
using System.Net;
using Android.Content;

namespace AppTabas.Activities
{
    /// <summary>
    /// This class represents the first view seen when the app is opened.
    /// It inherits from the base class for Android activities
    /// </summary>
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private const string Ipv4 = "192.168.0.11";
        public const string baseAddress = "http://" + Ipv4 + ":32967/api/";
        private EditText _userId;
        private EditText _userPassword;
        private Button _signInButton;
        private Toast _toast;

        /// <summary>
        /// This method is called when the activity is starting.
        /// It contains the logic for the buttons shown in the first view.
        /// </summary>
        /// <param name="savedInstanceState"> a Bundle that contains the data the activity most recently
        /// supplied if the activity is being re-initialized after previously being shut down. </param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState); 
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            _userId = FindViewById<EditText>(Resource.Id.signInId);
            _userPassword = FindViewById<EditText>(Resource.Id.signInPassword);
            _signInButton = FindViewById<Button>(Resource.Id.btnSignIn);

            // Manages the user info entered for the sign in
            _signInButton.Click += (sender, args) =>
            {
                string toastText;
                var userIdInput = _userId.Text;
                var userPasswordInput = _userPassword.Text;
                bool isPassNum = int.TryParse(userIdInput, out int userIdNum);

                if (userIdInput.Equals("") || userPasswordInput.Equals(""))
                {
                    toastText = "Debe ingresar la información solicitada.";
                }

                else if (!isPassNum)
                {
                    toastText = "La cédula debe ser un número";
                }

                else
                {
                    var user = new User(userIdNum, userPasswordInput);
                    var jsonResult = JsonConvert.SerializeObject(user);

                    using var webClient = new WebClient { BaseAddress = baseAddress };
                    var url = "Usuario/IniciarSesion";
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var send = webClient.UploadString(url, jsonResult);

                    var response = send;

                    if (response.Equals("OK"))
                    {
                        toastText = "Sesión iniciada";

                        // Open new page/layout on the app
                        var intent = new Intent(this, typeof(BagsActivity));
                        intent.PutExtra("WorkerId", userIdInput); //Pass info on to the next activity
                        StartActivity(intent);
                        OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
                        Finish();
                    }
                    else
                    {
                        toastText = "La cédula o la contraseña son incorrectas";
                    }

                }
                _toast = Toast.MakeText(this, toastText, ToastLength.Short);
                _toast.Show();
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}