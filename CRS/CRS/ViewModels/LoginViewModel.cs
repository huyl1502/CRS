using CRS.Utilities;
using CRS.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static CRS.Utilities.Constant;

namespace CRS.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        string userName;
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        string password;
        public string PassWord
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            ShowLoading = true;
            await ApiClient.PostDataAsync(ApiUrl.Login, new { _id = UserName, Password = PassWord });
            await Shell.Current.GoToAsync($"//{nameof(RatingPage)}");
            ShowLoading = false;
        }
    }
}

