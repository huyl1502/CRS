using System.ComponentModel;
using Xamarin.Forms;
using CRS.ViewModels;

namespace CRS.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
