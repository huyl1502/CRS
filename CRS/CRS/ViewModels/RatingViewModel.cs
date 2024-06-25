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
                var x = SelectedValue;
                SetBannerWidth();
            };
        }

        private void SetBannerWidth()
        {
            double screenWidth = DeviceDisplay.MainDisplayInfo.Width;
            double desiredWidth = screenWidth * 0.65; // 50% of screen width
            BannerWidth = desiredWidth;
        }

        //show/hide send button
        private bool _isSendButtonVisible;
        public bool IsSendButtonVisible
        {
            get { return _isSendButtonVisible; }
            set { SetProperty(ref _isSendButtonVisible, value); }
        }

        private int _selectedValue;
        public int SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                _selectedValue = value;
                OnSelectedValueChanged(nameof(SelectedValue));
                IsSendButtonVisible = _selectedValue == 0 ? false : true;
            }
        }

        public event PropertyChangedEventHandler SelectedValueChanged;
        protected virtual void OnSelectedValueChanged(string propertyName)
        {
            SelectedValueChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
