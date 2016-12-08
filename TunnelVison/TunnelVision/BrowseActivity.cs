using System;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Support.V7.App;
using Android.Widget;

namespace TunnelVision
{
    [Activity(Label = "Tunnel Vision")]
    public class BrowseActivity : AppCompatActivity
    {
        Button nextBtn;
        Button prevBtn;
        WebView displayedMap;
        int width;
        string data;
        string mapPrefix = "file:///android_asset/Maps/";
        string defaultMap = "map_MAC1.png";
        string currentMap = "";
        List<String> mapList;
        int mapIndex = 0;

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

            /*
            FindViewById<Button>(Resource.Id.prevBtn).Click += (sender, e) =>
            {
                if (mapList.Count < mapIndex)
                {
                    --mapIndex;
                    ChangeMap(mapList[mapIndex]);
                }
            }; ;

            FindViewById<Button>(Resource.Id.nextBtn).Click += (sender, e) =>
            {
                if (mapIndex < mapList.Count)
                {
                    ++mapIndex;
                    ChangeMap(mapList[mapIndex]);
                }
            };
            */
            
            displayedMap = FindViewById<WebView>(Resource.Id.displayedMap);
            displayedMap.SetWebViewClient(new WebViewClient()); // stops request going to Web Browser

            SetDisplaySettings();

            //ChangeMap("TestRainbow.png");
            if (Intent.Extras != null)
            {
                ChangeMap(Intent.Extras.GetString("mapName"));
            }
            else
            {
                ChangeMap(defaultMap);
            }
            
        }

        //===============================================================================================

        public void SetDisplaySettings()
        {
            displayedMap.Settings.JavaScriptEnabled = true;
            displayedMap.Settings.BuiltInZoomControls = true;
            displayedMap.Settings.DisplayZoomControls = false;
            displayedMap.Settings.UseWideViewPort = true;
        }

        //===============================================================================================

        public void ChangeMap(string mapName)
        {
            data = "<html><head><title>Map</title><meta name=\"viewport\"\"content=\"width=" + width + ", initial-scale=0.65 \" /></head>";
            //data += "<body><center><img width=\"" + width + "\" src=\"" + mapPrefix + mapName + "\" /></center></body></html>";       //Different version of below line
            data += "<body><center><img src=\"" + mapPrefix + mapName + "\" /></center></body></html>";

            //displayedMap.LoadUrl("http://google.com");
            displayedMap.LoadUrl(mapPrefix + mapName);
            //displayedMap.LoadUrl("file:///android_asset/Maps/TestRainbow.png");
            //displayedMap.LoadDataWithBaseURL(null, data, "text/html", "utf-8", null);
            
            currentMap = mapName;

        }

        //===============================================================================================

        public void AddMapToList(string map)
        {
            mapList.Add(map);
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