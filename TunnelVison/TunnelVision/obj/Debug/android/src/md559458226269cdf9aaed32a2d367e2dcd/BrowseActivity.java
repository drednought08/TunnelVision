package md559458226269cdf9aaed32a2d367e2dcd;


public class BrowseActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("TunnelVision.BrowseActivity, TunnelVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BrowseActivity.class, __md_methods);
	}


	public BrowseActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == BrowseActivity.class)
			mono.android.TypeManager.Activate ("TunnelVision.BrowseActivity, TunnelVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
