using System;
using Xamarin.Forms;

namespace CRS.Views
{
    public class BasePage : ContentPage
    {
        public static readonly BindableProperty RootViewModelProperty =
           BindableProperty.Create(
               "RootViewModel", typeof(object), typeof(BasePage),
               defaultValue: default(object));

        public object RootViewModel
        {
            get { return (object)GetValue(RootViewModelProperty); }
            set { SetValue(RootViewModelProperty, value); }
        }
    }
}