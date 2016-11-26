using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Graphics;
using System;

namespace TunnelVision
{
    [Activity(Label = "Tunnel Vision", MainLauncher = true, Icon = "@mipmap/icon")]
	public class BrowseActivity : Activity
	{
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
}

