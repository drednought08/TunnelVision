package md559458226269cdf9aaed32a2d367e2dcd;


public class BrowseActivity_ScaleListener
	extends android.view.ScaleGestureDetector.SimpleOnScaleGestureListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onScale:(Landroid/view/ScaleGestureDetector;)Z:GetOnScale_Landroid_view_ScaleGestureDetector_Handler\n" +
			"";
		mono.android.Runtime.register ("TunnelVision.BrowseActivity+ScaleListener, TunnelVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BrowseActivity_ScaleListener.class, __md_methods);
	}


	public BrowseActivity_ScaleListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == BrowseActivity_ScaleListener.class)
			mono.android.TypeManager.Activate ("TunnelVision.BrowseActivity+ScaleListener, TunnelVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public BrowseActivity_ScaleListener (md559458226269cdf9aaed32a2d367e2dcd.BrowseActivity p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == BrowseActivity_ScaleListener.class)
			mono.android.TypeManager.Activate ("TunnelVision.BrowseActivity+ScaleListener, TunnelVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "TunnelVision.BrowseActivity, TunnelVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public boolean onScale (android.view.ScaleGestureDetector p0)
	{
		return n_onScale (p0);
	}

	private native boolean n_onScale (android.view.ScaleGestureDetector p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
