using CRS.Models;
using CRS.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using CRS.Services;
using System.Linq;
using CRS.Utilities;

namespace CRS.Views.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyRating : ContentView
    {
        List<MyRatingIcon> LstRatingIcons { get; set; }

        public static readonly BindableProperty ShowLoadingProperty = BindableProperty.Create(
            nameof(ShowLoading),
            typeof(bool),
            typeof(MyRating),
            false);

        public bool ShowLoading
        {
            get => (bool)GetValue(ShowLoadingProperty);
            set => SetValue(ShowLoadingProperty, value);
        }

        public MyRating()
        {
            InitializeComponent();

            var tapGestureRecognizer = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
            tapGestureRecognizer.Tapped += OnTapped;

            var ratingIconConfig = new RatingIconConfigService();
            LstRatingIcons = ratingIconConfig.Config.ListRatingIcon.Select(ratingIcon => new MyRatingIcon
            {
                UnSelectedIcon = ratingIcon.UnSelectedIcon,
                SelectedIcon = ratingIcon.SelectedIcon,
                Label = ratingIcon.Label,
                Point = ratingIcon.Point,
            }).ToList();

            LstRatingIcons.ForEach(icon =>
            {
                icon.GestureRecognizers.Add(tapGestureRecognizer);
                MainContent.Children.Add(icon);
            });
        }

        async void OnTapped(object sender, EventArgs e)
        {
            ShowLoading = true;
            ReloadListRating();
            var selectedItem = ((MyRatingIcon)sender);
            selectedItem.IsSelected = true;
            await Navigation.PushAsync(new ReasonPage(new Dictionary<string, string> { { nameof(ReasonPage.RatingPoint), selectedItem.Point.ToString() } }));
            //await Shell.Current.GoToAsync($"{nameof(ReasonPage)}?{nameof(ReasonPage.RatingPoint)}={selectedItem.Point}");
            ShowLoading = false;
        }

        public void ReloadListRating()
        {
            LstRatingIcons.ForEach(icon =>
            {
                icon.IsSelected = false;
            });
        }
    }
}