using Android.App;
using Android.OS;
using AndroidX.AppCompat.App;
using Android.Widget;
using Newtonsoft.Json;

namespace TABAS
{
    /// <summary>
    /// This class represents the first view seen when the app is opened.
    /// It inherits from the base class for Android activities
    /// </summary>
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _signInButton;
        private EditText _userId;
        private EditText _userPassword;
        private Toast _toast;
        public const string Ipv4 = "192.168.1.2";

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
            SetContentView(Resource.Layout.Main);

            _userId = FindViewById<EditText>(Resource.Id.signInId);
            _userPassword = FindViewById<EditText>(Resource.Id.signInPassword);
            _signInButton = FindViewById<Button>(Resource.Id.btnSignIn);
            string toastText;

            // Manages the user info entered for the sign in
            _signInButton.Click += (sender, args) =>
            {
                var userEmailInput = _userId.Text;
                var userPasswordInput = _userPassword.Text;

                if (userEmailInput.Equals("") || userPasswordInput.Equals(""))
                {
                    toastText = "Debe ingresar la información solicitada.";
                }

                else
                {
                    /*using var webClient = new WebClient { BaseAddress = "http://" + MainActivity.Ipv4 + ":8080/CookTime_war/cookAPI/" };
                    var url = "resources/auth?email=" + userEmailInput + "&password=" + userPasswordInput;
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var send = webClient.DownloadString(url);

                    var response = JsonConvert.DeserializeObject<string>(send);

                    value = response;*/

                    toastText = "Sesión iniciada";
                }
                _toast = Toast.MakeText(this, toastText, ToastLength.Short);
                _toast.Show();
            };
        }
           
    }
}