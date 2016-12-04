
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace TunnelVision
{
	[Activity(Label = "SettingsActivity")]
	public class SettingsActivity : AppCompatActivity
	{

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.settings);


			var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);
			SupportActionBar.Title = "Settings";
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			SupportActionBar.SetHomeButtonEnabled(true);

			FindViewById<Button>(Resource.Id.btnToolbarRed).Click += (sender, e) =>
			{
				toolbar.SetBackgroundResource(Resource.Color.aRed);
			};
			FindViewById<Button>(Resource.Id.btnToolbarBlue).Click += (sender, e) =>
			{
				toolbar.SetBackgroundResource(Resource.Color.aBlue);
			};
			FindViewById<Button>(Resource.Id.btnToolbarGreen).Click += (sender, e) =>
			{
				toolbar.SetBackgroundResource(Resource.Color.aGreen);
			};
			FindViewById<Button>(Resource.Id.btnToolbarBlack).Click += (sender, e) =>
			{
				toolbar.SetBackgroundResource(Resource.Color.aBlack);
			};
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
