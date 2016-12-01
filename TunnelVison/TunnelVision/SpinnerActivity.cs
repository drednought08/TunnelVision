using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;

namespace TunnelVision
{
    [Activity(Label = "SpinnerActivity")]
	public class SpinnerActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.getRoute);


			/** IMPORTANT
  				* include this section in a activity file for the toolbar
 				* 5 lines from var toolbar to SupportActionBar.SetHomeButtonEnabled(true);
  				* also add the public override bool OnOptionsItemSelected(IMenuItem item) method like below for the back arrow button function
  				* and include <include
        						android:id="@+id/toolbar"
        						layout="@layout/toolbar" />
        			in the axml file like in getRoute.axml			
			*/
			var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);
			SupportActionBar.Title = "Get Route";
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			SupportActionBar.SetHomeButtonEnabled(true);


			//spinner1
			Spinner spinner1 = FindViewById<Spinner>(Resource.Id.spinner1);

			spinner1.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner1_ItemSelected);
			var adapter1 = ArrayAdapter.CreateFromResource(
					this, Resource.Array.building_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner1.Adapter = adapter1;


			//spinner2
			Spinner spinner2 = FindViewById<Spinner>(Resource.Id.spinner2);

			spinner2.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner2_ItemSelected);
			var adapter2 = ArrayAdapter.CreateFromResource(
					this, Resource.Array.building_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner2.Adapter = adapter2;


			//spinner3
			Spinner spinner3 = FindViewById<Spinner>(Resource.Id.spinner3);

			spinner3.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner3_ItemSelected);
			var adapter3 = ArrayAdapter.CreateFromResource(
					this, Resource.Array.location_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter3.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner3.Adapter = adapter3;

			//spinner4
			Spinner spinner4 = FindViewById<Spinner>(Resource.Id.spinner4);

			spinner4.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner4_ItemSelected);
			var adapter4 = ArrayAdapter.CreateFromResource(
					this, Resource.Array.location_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter4.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner4.Adapter = adapter4;
		}

		//spinner1
		private void spinner1_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner1 = (Spinner)sender;

			//For testing action after selecting list item
			string toast = string.Format("TESTINGSPINNER1-Your choice is {0}", spinner1.GetItemAtPosition(e.Position));
			Toast.MakeText(this, toast, ToastLength.Long).Show();
		}

		//spinner2 
		private void spinner2_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner2 = (Spinner)sender;

			//For testing action after selecting list item
			string toast = string.Format("TESTINGSPINNER2-Your choice is {0}", spinner2.GetItemAtPosition(e.Position));
			Toast.MakeText(this, toast, ToastLength.Long).Show();
		}

		//spinner3 
		private void spinner3_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner3 = (Spinner)sender;

			//For testing action after selecting list item
			string toast = string.Format("TESTINGSPINNER3-Your choice is {0}", spinner3.GetItemAtPosition(e.Position));
			Toast.MakeText(this, toast, ToastLength.Long).Show();
		}

		//spinner4 
		private void spinner4_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner4 = (Spinner)sender;

			//For testing action after selecting list item
			string toast = string.Format("TESTINGSPINNER4-Your choice is {0}", spinner4.GetItemAtPosition(e.Position));
			Toast.MakeText(this, toast, ToastLength.Long).Show();
		}

		//a toolbar method
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			if (item.ItemId == Android.Resource.Id.Home)
				Finish();

			return base.OnOptionsItemSelected(item);
		}
	}
}
