using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CRS.ViewModels
{
    public class RatingViewModel : BaseViewModel
    {
        public RatingViewModel()
        {
            Title = "Rating";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
