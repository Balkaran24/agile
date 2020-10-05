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
    [Activity(Label = "Create_Sub_Master")]
    public class Create_Sub_Master : Activity
    {

        List<SubAccountTable> List_All_Sub;
        List<MasterTable > List_All_Master;
        EditText txtsubmastergpname;
        Button btnsavesubmastergp;
        Button btndeletesubmastergp;
        Button btnupdatesubmastergp;
        Button btnnewsubmastergp;

        Spinner spinnershowmaster;
        Spinner spinnershowsubmaster;
      
        TextView txtsubmasterid;
        TextView txtmasterid;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateSubMaster);

            btnnewsubmastergp = FindViewById<Button>(Resource.Id.btn_new_sub_master_gp);

            btnsavesubmastergp = FindViewById<Button>(Resource.Id.btn_save_sub_master_gp);

            btndeletesubmastergp = FindViewById<Button>(Resource.Id.btn_delete_sub_master_gp);
            btnupdatesubmastergp = FindViewById<Button>(Resource.Id.btn_update_sub_master_gp);
            txtsubmastergpname = FindViewById<EditText>(Resource.Id.txt_sub_master_gp_name);
            spinnershowmaster = FindViewById<Spinner>(Resource.Id.spinner_show_master);
            spinnershowsubmaster = FindViewById<Spinner>(Resource.Id.spinner_show_sub);

            txtsubmasterid = FindViewById<TextView>(Resource.Id.txt_v_sub_master_id);
            txtmasterid = FindViewById<TextView>(Resource.Id.txt_master_id);

            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "accounts.sqlite");
            var db = new SQLiteConnection(dpPath);

            db.CreateTable<SubAccountTable >();






            load_spiner_master();
            load_spiner_sub_master();


            spinnershowmaster.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_show_Master_ItemSelected);
            spinnershowsubmaster.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_show_Sub_Master_ItemSelected);
            btnsavesubmastergp.Click += Btnsavesubmastergp_Click;
            btndeletesubmastergp.Click += Btndeletesubmastergp_Click;
            btnupdatesubmastergp.Click += Btnupdatesubmastergp_Click;

        }

        private void Btnupdatesubmastergp_Click(object sender, EventArgs e)
        {
            var item_sub = new SubAccountTable();
            item_sub.Id = Convert.ToInt32(txtsubmasterid .Text );
            item_sub.subaccountname = txtsubmastergpname.Text;
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "accounts.sqlite");
            var db = new SQLiteConnection(dpPath);
          
            //db.Update(item_sub);

            Toast.MakeText(this, "Record Updated Successfully...,", ToastLength.Short).Show();

            load_spiner_master();
            load_spiner_sub_master();
        }

        private void Btndeletesubmastergp_Click(object sender, EventArgs e)
        {
            var item = new SubAccountTable();
            item.Id = Convert.ToInt32(txtsubmasterid .Text );
            
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "accounts.sqlite");
            var db = new SQLiteConnection(dpPath);
            var data = db.Delete(item);
            Toast.MakeText(this, "Record Deleted Successfully...,", ToastLength.Short).Show();
            txtsubmastergpname .Text  = "";
            load_spiner_master();
            load_spiner_sub_master();
        }

        private void Btnsavesubmastergp_Click(object sender, EventArgs e)
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "accounts.sqlite");
            var db = new SQLiteConnection(dpPath);
            db.CreateTable<SubAccountTable>();
            SubAccountTable  tbl = new SubAccountTable ();
            tbl.subaccountname  = Convert.ToString (txtsubmastergpname.Text);
            tbl.MId = Convert.ToInt32 (txtmasterid.Text);
            db.Insert(tbl);
            Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();
            txtsubmastergpname.Text = "";
            load_spiner_master();
            load_spiner_sub_master();
           
        }

        private void spinner_show_Sub_Master_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            var id = this.List_All_Sub.ElementAt(e.Position).Id;
            var subaccountname = this.List_All_Sub.ElementAt(e.Position).subaccountname ;
            txtsubmasterid.Text = Convert.ToString(id);
            // txtmastergp.Text = masteraccountname;
          
        }

        private void spinner_show_Master_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;
            var id = this.List_All_Master.ElementAt(e.Position).Id;

            txtmasterid.Text = Convert.ToString(id);
           
            load_spiner_sub_master();
        }

        private void load_spiner_master()
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "accounts.sqlite");
            var db = new SQLiteConnection(dpPath);
            var data_s = db.Query<MasterTable>("select *  from MasterTable");
            List_All_Master = data_s;
            Agile_2.Resources.MyAdapter_Master_gp da = new Resources.MyAdapter_Master_gp(this, List_All_Master);
            spinnershowmaster.Adapter = da;
           
        }

        private void load_spiner_sub_master()
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "accounts.sqlite");
            var db = new SQLiteConnection(dpPath);
            var data_s = db.Query<SubAccountTable >("select *  from SubAccountTable where mid=" + txtmasterid .Text );
            List_All_Sub = data_s;
            Agile_2.Resources.MyAdapter_Sub_Master_Gp da = new Resources.MyAdapter_Sub_Master_Gp(this, List_All_Sub);
            spinnershowsubmaster.Adapter = da;
        }
    }
}