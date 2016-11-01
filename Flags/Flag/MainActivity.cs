using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace Flag
{
    [Activity(Label = "Flag", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        HttpClient client = new HttpClient();
        private TextView AText;
        private TextView BText;
        private TextView ResponseText;
        private Button UpdateButton;
        private Button ReadButton;
        private string serverIP = "192.168.0.117";
        //private string port = "8080";
        private string port = "8001";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            AText = FindViewById<EditText>(Resource.Id.editTextA);
            BText = FindViewById<EditText>(Resource.Id.editTextB);
            ResponseText = FindViewById<TextView>(Resource.Id.editTextResponse);
            UpdateButton = FindViewById<Button>(Resource.Id.updateButton);
            UpdateButton.Click += UpdateButtonClickOn;
            ReadButton = FindViewById<Button>(Resource.Id.readButton);
            ReadButton.Click += ReadButtonClickOn;

        }
        private async void UpdateButtonClickOn(object sender, EventArgs e)
        {
            try { 
            //string serverIP = "192.168.0.117";
            //string port = "8080";
            string WebService = "WebService1";
            string urlString = "http://" + serverIP + ":" + port + "/" + WebService + "/" + "UpdateFlagState";
                //Local
            //string urlString = "http://127.0.0.1:8001/WebService1/UpdateFlagState";
            string json = "Room=" + AText.Text + "&FlagState=" + BText.Text;
                //var postContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postContent = new StringContent(json, Encoding.UTF8, "application/x-www-form-urlencoded");
                //"http://192.168.0.117:8080/WebService1/UpdateFlag?Room=0&FlagIn=3"
                //Task<string> getStringTask = client.GetStringAsync(urlString);
                HttpResponseMessage urlContents = await client.PostAsync(urlString, postContent);
                //jresponse= JsonConvert .DeserializeObject
                //CText.Text = jresponse.c;
                var urlbody = await urlContents.Content.ReadAsStringAsync();
                ResponseText.Text = urlbody.ToString();
                    }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        private async void ReadButtonClickOn(object sender, EventArgs e)
        {
           
            //string serverIP = "192.168.0.117";
            //string port = "8080";
            string WebService = "WebService1";
            string urlString = "http://" + serverIP + ":" + port + "/" + WebService + "/" + "ReadFlag?Room=" + AText.Text;
                        //"http://192.168.0.117:8080/WebService1/Add?b=2&a=9"
            //http://192.168.0.117:8080/WebService1/ReadFlag?Room=0
            Task<string> getStringTask = client.GetStringAsync(urlString);
            string urlContents = await getStringTask;
            //jresponse= JsonConvert .DeserializeObject
            //CText.Text = jresponse.c;
            ResponseText.Text = urlContents;
        }



    }
    
}

