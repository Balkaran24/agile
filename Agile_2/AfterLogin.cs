using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Agile_2
{
    [Activity(Label = "AfterLogin")]
    public class AfterLogin : Activity
    {
        Button btnshowmaster;
        Button btnshowsubmaster;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AfterLogin );
            btnshowmaster = FindViewById<Button>(Resource.Id.btn_show_master);
            btnshowsubmaster = FindViewById<Button>(Resource.Id.btn_show_sub_master);


            btnshowmaster.Click += btnshowmaster_Click;
            btnshowsubmaster.Click += btnshowsubmaster_Click;

        }

        private void btnshowsubmaster_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Create_Sub_Master));
        }

        private void btnshowmaster_Click(object sender, EventArgs e)
        {
           // StartActivity(typeof(Create_Sub_Master));
            StartActivity(typeof(Create_Master));
        }
    }
}