using Android.App;
using Android.OS;
using Android.Webkit;

namespace TunnelVision
{
    [Activity(Label = "Tunnel Vision")]
    public class BrowseActivity : Activity
    {
        WebView displayedMap;
        int width;
        string data;
        string mapPrefix = "file:///android_asset/Maps/";
        string defaultMap = "TestRainbow.png";
        string currentMap = "";

        public void onCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Browse);

            width = Resources.DisplayMetrics.WidthPixels;
            displayedMap = FindViewById<WebView>(Resource.Id.displayedMap);
            displayedMap.Invalidate();
            //SetDisplaySettings();
            //displayedMap.SetLayerType(LayerType.Software, null);
            displayedMap.LoadUrl("http://www.google.com");
            displayedMap.Invalidate();

            //ChangeMap(defaultMap);

            string toast = string.Format("Displayed URL is: {0}", displayedMap.Url);
            Android.Widget.Toast.MakeText(this, toast, Android.Widget.ToastLength.Long).Show();
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
            //data = "<html><head><title>Map</title><meta name=\"viewport\"\"content=\"width=" + width + ", initial-scale=0.65 \" /></head>";
            //data += "<body><center><img width=\"" + width + "\" src=\"" + mapPrefix + mapName + "\" /></center></body></html>";
            data = "<html><head></head><body><img src=\"" + mapPrefix + mapName + "\"/></body></html>";

            //displayedMap.LoadUrl(mapPrefix + mapName);
            //displayedMap.LoadData(data, "text/html", "UTF-8");
            //displayedMap.LoadUrl("file:///android_asset/Maps/TestRainbow.png");
            //displayedMap.LoadData(data, "text/html", null);
            // displayedMap.LoadDataWithBaseURL(null, "<style>img{display: inline;height: auto;max-width: 100%;}</style>" + .getContent(), "text/html", "UTF-8", null);

            
            currentMap = mapName;

        }




            //ImageView version. Not working
            /*
            public ImageView displayedMap;
            ScaleGestureDetector scaleGestureDetector;
            Matrix matrix = new Matrix();

            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);

                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);

                // Get our button from the layout resource,
                // and attach an event to it
                displayedMap = FindViewById<ImageView>(Resource.Id.displayedMap);
                displayedMap.SetImageResource(Resource.Drawable.TestRainbow);	//Default done in the displayedMap's properties. This is for testing
                scaleGestureDetector = new ScaleGestureDetector(this, new ScaleListener(this));
            }

            //===============================================================================================
            #region Image scaling implementation //Testing. Currently zooms in on startup and doesn't pan

            public override bool OnTouchEvent(MotionEvent e)
            {
                scaleGestureDetector.OnTouchEvent(e);
                return true;
            }

            //===============================================================================================

            private class ScaleListener : ScaleGestureDetector.SimpleOnScaleGestureListener
            {
                private BrowseActivity browseActivity;

                public ScaleListener(BrowseActivity browseActivity)
                {
                    this.browseActivity = browseActivity;
                }

                public override bool OnScale(ScaleGestureDetector detector)
                {
                    float scaleFactor = detector.ScaleFactor;
                    scaleFactor = Math.Max(0.1f, Math.Min(scaleFactor, 5.0f));

                    browseActivity.matrix.SetScale(scaleFactor, scaleFactor);
                    return true;
                }
            }
        }

        #endregion

        //===============================================================================================



        //===============================================================================================
        */

    }
}

