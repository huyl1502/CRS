using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CRS.Droid;
using CRS.ViewModels;
using Plugin.MaterialDesignControls.Material3.Android;
using Xamarin.Forms;
using Color = Android.Graphics.Color;

[assembly: Xamarin.Forms.Dependency(typeof(CRS.Droid.AndroidToast))]

namespace CRS.Droid
{
    public class AndroidToast : ICustomToast
    {
        public void Show(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                LayoutInflater inflater = (LayoutInflater)Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService);
                Android.Views.View layout = inflater.Inflate(Resource.Layout.custom_toast, null);

                Color c = Color.Rgb(51, 51, 51);
                layout.SetBackgroundColor(c);
                layout.ClipToOutline = true;
                layout.OutlineProvider = new RoundedCornerOutlineProvider(40);

                TextView text = layout.FindViewById<TextView>(Resource.Id.toast_text);
                text.Text = message;

                Toast toast = new Toast(Android.App.Application.Context)
                {
                    Duration = ToastLength.Short,
                    View = layout
                };

                toast.SetGravity(GravityFlags.Center, 0, 0);
                toast.Show();
            });
        }
    }

    public class RoundedCornerOutlineProvider : ViewOutlineProvider
    {
        private float _radius;

        public RoundedCornerOutlineProvider(float radius)
        {
            _radius = radius;
        }

        public override void GetOutline(Android.Views.View view, Outline outline)
        {
            outline.SetRoundRect(0, 0, view.Width, view.Height, _radius);
        }
    }
}