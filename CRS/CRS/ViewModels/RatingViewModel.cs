using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CRS.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CRS.ViewModels
{
    public class RatingViewModel : BaseViewModel
    {
        public RatingViewModel()
        {
            Title = "Bảng đánh giá sự hài lòng của khách hàng";
            OpenWebCommand = new Command(OnSubmitClicked);
        }

        public ICommand OpenWebCommand { get; }

        private async void OnSubmitClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            ShowLoading = true;
            var lstAddress = Utilities.Utilities.GetMacAddress();
            foreach(var add in lstAddress)
            {
                Console.WriteLine(add.ToString());
            }
            await Task.Delay(3000);
            ShowLoading = false;
        }
    }
}
