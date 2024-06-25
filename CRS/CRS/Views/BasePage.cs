using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static CRS.Utilities.Constant;

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