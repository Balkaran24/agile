using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Agile_2.Resources;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Agile_2
{
    [Activity(Label = "Create_Master")]
    public class Create_Master : Activity
    {


        List<MasterTable> List_All;
        EditText txtmastergp;
        Button btnsavemastergp;
        Button btndeletemastergp;
        Button btnupdatemastergp;
        Button btnnewmastergp;


        Spinner spinner;
        TextView txtviewid;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CreateMaster );
            // Create your application here


            btnsavemastergp = FindViewById<Button>(Resource.Id.btn_save_master_gp);
            btndeletemastergp= FindViewById<Button>(Resource.Id.btn_delete_master_gp);

            btnnewmastergp = FindViewById<Button>(Resource.Id.btn_new_master_gp);
            btnupdatemastergp = FindViewById<Button>(Resource.Id.btn_update_master_gp);
            txtmastergp = FindViewById<EditText>(Resource.Id.txt_master_gp);
            spinner = FindViewById<Spinner>(Resource.Id.spinner_show);
            txtviewid = FindViewById<TextView >(Resource.Id.txt_v_master_id);


            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "accounts.sqlite");
            var db = new SQLiteConnection(dpPath);
                      
            db.CreateTable<MasterTable>();




          
         
            load_spiner_master();

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_show_ItemSelected);


            btnsavemastergp.Click += Btnsavemastergp_Click; ;
            btnnewmastergp.Click += Btnnewmastergp_Click;
            btndeletemastergp.Click += Btndeletemastergp_Click;
            btnupdatemastergp.Click += Btnupdatemastergp_Click;

        }

        private void Btnupdatemastergp_Click(object sender, EventArgs e)
        {

            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "accounts.sqlite");
            var db = new SQLiteConnection(dpPath);
           
          



            var item = new MasterTable ();

             item.Id = Convert.ToInt32 (txtviewid .Text) ;
         
           


            item.MasterName  = txtmastergp .Text ;
           

            db.Update(item);

            Toast.MakeText(this, "Record Updated Successfully...,", ToastLength.Short).Show();

            load_spiner_master();
        }

        private void Btnnewmastergp_Click(object sender, EventArgs e)
        {
            txtmastergp.Text = "";

        }

        private void Btndeletemastergp_Click(object sender, EventArgs e)
        {
           
            


            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "accounts.sqlite");
            var db = new SQLiteConnection(dpPath);

            
            var subitem = new SubAccountTable();
            subitem.MId = Convert.ToInt32(txtviewid.Text);

            var data_s = db.Query<SubAccountTable>("select *  from SubAccountTable where mid=" + Convert.ToInt32(txtviewid.Text));
            if(data_s .Count > 0)
            {
                Toast.MakeText(this, "Record Will not deleted as Sub A/c Exists...,", ToastLength.Short).Show();

            }
            else
            {
                var item = new MasterTable();
                item.Id = Convert.ToInt32(txtviewid.Text);
                var data = db.Delete(item);
                Toast.MakeText(this, "Record Deleted Successfully...,", ToastLength.Short).Show();
                txtmastergp.Text = "";
                load_spiner_master();

            }
           

         



         
        }

        private void spinner_show_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
          
            Spinner spinner = (Spinner)sender;
            var id  = this.List_All.ElementAt(e.Position).Id;
            var masteraccountname= this.List_All.ElementAt(e.Position).MasterName ;
           txtviewid.Text   = Convert.ToString (id);
           // txtmastergp.Text = masteraccountname;
            btndeletemastergp.Enabled = true;
           
        }

        private void Btnsavemastergp_Click(object sender, EventArgs e)
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "accounts.sqlite");
            var db = new SQLiteConnection(dpPath);
            db.CreateTable<MasterTable>();
            MasterTable tbl = new MasterTable();
            tbl.MasterName  = txtmastergp .Text ;
            db.Insert(tbl);
            Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();
            txtmastergp.Text = "";
            load_spiner_master();

        }

        private void load_spiner_master()
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "accounts.sqlite");
            var db = new SQLiteConnection(dpPath);
            var data_s = db.Query<MasterTable>("select *  from MasterTable");
            List_All = data_s;
            Agile_2.Resources.MyAdapter_Master_gp da = new Resources.MyAdapter_Master_gp(this, List_All);
            spinner.Adapter = da;
           
        }
    }
}