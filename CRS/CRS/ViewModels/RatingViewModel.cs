using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CRS.Views;
using CRS.Views.Components;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CRS.ViewModels
{
    public class RatingViewModel : BaseViewModel
    {
        double bannerWidth;
        public double BannerWidth
        {
            get { return bannerWidth; }
            set { SetProperty(ref bannerWidth, value); }
        }

        public RatingViewModel()
        {
            Title = "Bảng đánh giá chất lượng dịch vụ";

            SetBannerWidth();
            DeviceDisplay.MainDisplayInfoChanged += (sender, args) =>
            {
                SetBannerWidth();
            };
        }

        private void SetBannerWidth()
        {
            double screenWidth = DeviceDisplay.MainDisplayInfo.Width;
            double desiredWidth = screenWidth * 0.65; // 50% of screen width
            BannerWidth = desiredWidth;
        }
    }
}
