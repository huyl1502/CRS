using System;
using System.ComponentModel;
using CRS.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatingPage : BasePage
    {
        public RatingPage()
        {
            InitializeComponent();
            this.BindingContext = new RatingViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            myRating.ReloadListRating();
        }
    }
}
