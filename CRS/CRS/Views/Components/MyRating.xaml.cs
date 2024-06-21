using CRS.Models;
using CRS.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace CRS.Views.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyRating : ContentView
    {
        List<MyRatingIcon> LstRatingIcons { get; set; }
        public MyRating()
        {
            InitializeComponent();

            var tapGestureRecognizer = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
            tapGestureRecognizer.Tapped += OnTapped;

            LstRatingIcons = new List<MyRatingIcon>
            {
                new MyRatingIcon { Icon="love.png", UnSelectedIcon="love.png", SelectedIcon="loveFull.png", Label="Rất hài lòng"},
                new MyRatingIcon { Icon="happy.png", UnSelectedIcon="happy.png", SelectedIcon="happyFull.png", Label="Hài lòng"},
                new MyRatingIcon { Icon="smile.png", UnSelectedIcon="smile.png", SelectedIcon="smileFull.png", Label="Bình thường"},
                new MyRatingIcon { Icon="crying.png", UnSelectedIcon="crying.png", SelectedIcon="cryingFull.png", Label="Không hài lòng"}
            };

            LstRatingIcons.ForEach(icon =>
            {
                icon.GestureRecognizers.Add(tapGestureRecognizer);
                MainContent.Children.Add(icon);
            });
        }

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

        async void OnTapped(object sender, EventArgs e)
        {
            ShowLoading = true;
            LstRatingIcons.ForEach(icon =>
            {
                icon.IsSelected = false;
                icon.Icon = icon.UnSelectedIcon;
            });
            ((MyRatingIcon)sender).IsSelected = true;
            await Task.Delay(10);
            await Shell.Current.GoToAsync($"{nameof(ReasonPage)}");
            ShowLoading = false;
        }
    }
}