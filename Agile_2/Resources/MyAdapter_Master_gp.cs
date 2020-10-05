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


namespace Agile_2.Resources
{
  
  public class MyAdapter_Master_gp : BaseAdapter<MasterTable>
    {
        private readonly Activity context;
        private readonly List<MasterTable> mItems;

        public MyAdapter_Master_gp(Activity context, List<MasterTable > items)
        {
            this.mItems = items;
            this.context = context;
        }



        public override int Count
        {
            get { return mItems.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override MasterTable  this[int position]
        {
            get { return mItems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var row = convertView;


            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.ListViewRow_Master, null, false);
            }

            // Set the txtRowName.Text which is in the listview_row layout to the Players Name
            TextView txtRowName = row.FindViewById<TextView>(Resource.Id.txtRowName);
            txtRowName.Text = mItems[position].MasterName ;

           

            return row;


        }
    }
}