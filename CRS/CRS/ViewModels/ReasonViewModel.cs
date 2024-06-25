using CRS.Models;
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

        public ICommand SendCommand { get; }

        private async void OnSubmitClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            ShowLoading = true;
            var lstAddress = Utilities.Utilities.GetMacAddress();
            var token = Utilities.Utilities.GetTokenAsync().Result;
            foreach (var add in lstAddress)
            {
                Console.WriteLine(token);
                Console.WriteLine(add.ToString());
            }
            await Task.Delay(3000);
            ShowLoading = false;
        }
    }
}
