using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using KalaCalcu.Droid;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]
namespace KalaCalcu.Droid
{
    public class CustomPickerRenderer : PickerRenderer
    {
        private Context context;
        public CustomPickerRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control == null || e.NewElement == null) return;
            //for example ,change the line to red:
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                Control.BackgroundTintList = ColorStateList.ValueOf(Color.Transparent);
            else
                Control.Background.SetColorFilter(Color.Red, PorterDuff.Mode.SrcAtop);
        }
    }
}