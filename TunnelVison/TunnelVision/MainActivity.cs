using Android.App;
using Android.Views;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace TunnelVision
{
	[Activity (Label = "Tunnel Vision", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : AppCompatActivity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var toolbar = FindViewById<Toolbar> (Resource.Id.toolbar);

			//Toolbar will now take on default actionbar characteristics
			SetSupportActionBar (toolbar);

			SupportActionBar.Title = "Tunnel Vision";


			FindViewById<Button>(Resource.Id.btnGetRoute).Click += (sender, e) =>
			{
				StartActivity(typeof(SpinnerActivity));
			};

            FindViewById<Button>(Resource.Id.btnViewMaps).Click += (sender, e) =>
            {
                StartActivity(typeof(BrowseActivity));      //Possible problem(s) with this line. Debugger can't step into it for me. "Frame not in module"
            };

            

            //FindViewById<Button>(Resource.Id.btnSubmit).Click += (sender, e) =>
            //{
            //StartActivity(typeof(LocationActivity));
            //};
        }

		/// <Docs>The options menu in which you place your items.</Docs>
		/// <returns>To be added.</returns>
		/// <summary>
		/// This is the menu for the Toolbar/Action Bar to use
		/// </summary>
		/// <param name="menu">Menu.</param>
		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.home, menu);
			return base.OnCreateOptionsMenu (menu);
		}

        /*
		public override bool OnOptionsItemSelected (IMenuItem item)
		{	
			Toast.MakeText(this, "Top ActionBar pressed: " + item.TitleFormatted, ToastLength.Short).Show();
			return base.OnOptionsItemSelected (item);
		}
        */

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_settings:
                    StartActivity(typeof(SettingsActivity));
                    return true;
                case Resource.Id.menu_share:
                    //
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}


