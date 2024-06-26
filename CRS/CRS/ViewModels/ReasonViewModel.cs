using CRS.Models;
using CRS.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using static CRS.Utilities.Constant;

namespace CRS.ViewModels
{
    public class ReasonViewModel : BaseViewModel
    {
        public ReasonViewModel()
        {
            SendCommand = new Command(OnSubmitClicked);
        }

        string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }

        public ICommand SendCommand { get; }

        private async void OnSubmitClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            ShowLoading = true;
            var lstAddress = Utilities.Utilities.GetMacAddress();
            var token = Utilities.Utilities.GetTokenAsync().Result;
            await Task.Delay(3000);
            ShowLoading = false;
            Toast("Đánh giá của quý khách đã được ghi nhận");
            await Task.Delay(3000);
            await Shell.Current.GoToAsync($"//{nameof(RatingPage)}");
        }
    }
}
