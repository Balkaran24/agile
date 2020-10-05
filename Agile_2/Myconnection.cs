using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Agile_2
{
   
    public class Myconnection
    {
        private string dbPath { get; set; }

        private SQLiteConnection db { get; set; }
        public Myconnection()
        {

            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "accounts.sqlite");

            db = new SQLiteConnection(dbPath);

           
        }

    }
}