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
using Android.Webkit;
using Android.Support.V7.App;
using Android.Util;

namespace TunnelVision
{
    [Activity(Label = "Tunnel Vision")]
    public class BrowseActivity : AppCompatActivity
    {
        WebView displayedMap;
        int width;
        string data;
        string mapPrefix = "file:///android_asset/Maps/";
        string defaultMap = "TestRainbow.png";
        string currentMap = "";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Browse);

            width = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "View Map";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            displayedMap = FindViewById<WebView>(Resource.Id.displayedMap);
            displayedMap.SetWebViewClient(new WebViewClient()); // stops request going to Web Browser

            SetDisplaySettings();
            
            ChangeMap("TestRainbow.png");
        }

        //===============================================================================================

        public void SetDisplaySettings()
        {
            displayedMap.Settings.JavaScriptEnabled = true;
            displayedMap.Settings.BuiltInZoomControls = true;
            displayedMap.Settings.UseWideViewPort = true;
        }

        //===============================================================================================

        public void ChangeMap(string mapName)
        {
            data = "<html><head><title>Map</title><meta name=\"viewport\"\"content=\"width=" + width + ", initial-scale=0.65 \" /></head>";
            //data += "<body><center><img width=\"" + width + "\" src=\"" + mapPrefix + mapName + "\" /></center></body></html>";       //Different version of below line
            data += "<body><center><img src=\"" + mapPrefix + mapName + "\" /></center></body></html>";

            //displayedMap.LoadUrl("http://google.com");
            //displayedMap.LoadUrl(mapPrefix + mapName);
            //displayedMap.LoadUrl("file:///android_asset/Maps/TestRainbow.png");
            displayedMap.LoadDataWithBaseURL(null, data, "text/html", "utf-8", null);
            
            currentMap = mapName;

        }

        //===============================================================================================

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();

            return base.OnOptionsItemSelected(item);
        }
    }
}