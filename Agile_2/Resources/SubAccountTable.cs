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
using SQLite;

namespace Agile_2.Resources
{
    public class SubAccountTable
    {
        [PrimaryKey, AutoIncrement] //Column("Id")]
        public int Id { get; set; }
        public int MId { get; set; }
        public string subaccountname { get; set; }
    }
}