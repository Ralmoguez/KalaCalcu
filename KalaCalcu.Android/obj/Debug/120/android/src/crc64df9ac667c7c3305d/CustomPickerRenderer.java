package crc64df9ac667c7c3305d;


public class CustomPickerRenderer
	extends crc643f46942d9dd1fff9.PickerRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("KalaCalcu.Droid.CustomPickerRenderer, KalaCalcu.Android", CustomPickerRenderer.class, __md_methods);
	}


	public CustomPickerRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CustomPickerRenderer.class) {
			mono.android.TypeManager.Activate ("KalaCalcu.Droid.CustomPickerRenderer, KalaCalcu.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public CustomPickerRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CustomPickerRenderer.class) {
			mono.android.TypeManager.Activate ("KalaCalcu.Droid.CustomPickerRenderer, KalaCalcu.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public CustomPickerRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CustomPickerRenderer.class) {
			mono.android.TypeManager.Activate ("KalaCalcu.Droid.CustomPickerRenderer, KalaCalcu.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
		}
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
