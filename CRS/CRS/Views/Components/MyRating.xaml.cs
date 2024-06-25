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

        public static readonly BindableProperty SelectedPointProperty =
        BindableProperty.Create(nameof(SelectedPoint), typeof(int), typeof(MyRating), null);

        public int SelectedPoint
        {
            get => (int)GetValue(SelectedPointProperty);
            set => SetValue(SelectedPointProperty, value);
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
            SelectedPoint = selectedItem.Point;
            if (selectedItem.Point == Constant.RatingPoint.Sad)
            {
                await Shell.Current.GoToAsync($"{nameof(ReasonPage)}");
            }
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