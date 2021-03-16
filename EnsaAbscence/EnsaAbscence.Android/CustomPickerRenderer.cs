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
using EnsaAbscence.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using EnsaAbscence.CustomControls;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace EnsaAbscence.Droid
{
    class CustomPickerRenderer:PickerRenderer
    {
        public CustomPickerRenderer(Context context) : base(context) { }
        public static void Init() { }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null; 

                var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                layoutParams.SetMargins(0, 0, 0, 0);
                LayoutParameters = layoutParams;
                Control.LayoutParameters = layoutParams;
                Control.SetPadding(5, 5, 5, 5);
                SetPadding(5, 5, 5, 5);
            }
        }
    }
}
