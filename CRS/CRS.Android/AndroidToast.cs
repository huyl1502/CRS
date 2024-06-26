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

                Color c = Color.Argb(100, 64, 64, 64);
                layout.SetBackgroundColor(c);

                TextView text = layout.FindViewById<TextView>(Resource.Id.toast_text);
                text.Text = message;
                text.SetTextColor(Color.White);

                Toast toast = new Toast(Android.App.Application.Context)
                {
                    Duration = ToastLength.Long,
                    View = layout
                };

                toast.SetGravity(GravityFlags.Center, 0, 0);
                toast.Show();
            });
        }
    }
}