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
   public class MyAdapter_Sub_Master_Gp : BaseAdapter<SubAccountTable>
    {
        private readonly Activity context;
        private readonly List<SubAccountTable> mItems;

        public MyAdapter_Sub_Master_Gp(Activity context, List<SubAccountTable> items)
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

        public override SubAccountTable this[int position]
        {
            get { return mItems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var row = convertView;


            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.ListViewRow_Sub_Master, null, false);
            }

            // Set the txtRowName.Text which is in the listview_row layout to the Players Name
            TextView txtRowName_Sub_Master = row.FindViewById<TextView>(Resource.Id.txtRowName_Sub_Master);
            txtRowName_Sub_Master.Text = mItems[position].subaccountname  ;



            return row;


        }
    }
}