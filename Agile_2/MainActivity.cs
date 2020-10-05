using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using SQLite;
using System.IO;

namespace Agile_2
{
    [Activity(Label = "Agile Accounts", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText txtusername;
        EditText txtPassword;
        Button btncreate;
        Button btnsign;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            btnsign = FindViewById<Button>(Resource.Id.btnlogin);
            btncreate = FindViewById<Button>(Resource.Id.btnregister);
            txtusername = FindViewById<EditText>(Resource.Id.txtusername);
            txtPassword = FindViewById<EditText>(Resource.Id.txtpwd);

            btnsign.Click += Btnsign_Click;
            btncreate.Click += Btncreate_Click;


        }

        private void Btncreate_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RegisterActivity));
        }

        private void Btnsign_Click(object sender, EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "accounts.sqlite");
                var db = new SQLiteConnection(dpPath);
                var data = db.Table<LoginTable>();

                var data1 = data.Where(x => x.username == txtusername.Text && x.password == txtPassword.Text).FirstOrDefault();

                if (data1 != null)
                {
                     Toast.MakeText(this, "Login Success", ToastLength.Short).Show();

                    StartActivity(typeof(AfterLogin ));

                }
                else
                {
                    Toast.MakeText(this, "Username or Password invalid", ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();

            }

        }






    }
}