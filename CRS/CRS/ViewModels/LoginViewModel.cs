using CRS.Models;
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
            try
            {
                var account = await ApiClient.PostDataAsync<Account>(ApiUrl.Login, new { _id = UserName, Password = PassWord });
                await Utilities.Utilities.SaveTokenAsync(account.Token);
                await Shell.Current.GoToAsync($"//{nameof(RatingPage)}");
            }
            catch (MyException ex)
            {
                Toast(ex.Msg);
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
            ShowLoading = false;
        }
    }
}

