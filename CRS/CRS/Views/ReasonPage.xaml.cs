using CRS.Services;
using CRS.ViewModels;
using Plugin.MaterialDesignControls.Material3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReasonPage : BasePage, IQueryAttributable
    {
        private int ratingPoint;
        public int RatingPoint
        {
            get { return ratingPoint; }
            set { ratingPoint = value; }
        }

        public ReasonPage() 
        {
            
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query.ContainsKey(nameof(RatingPoint)))
            {
                RatingPoint = int.Parse(query[nameof(RatingPoint)]);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            InitializeComponent();
            this.BindingContext = new ReasonViewModel();

            Color primaryColor = (Color)Application.Current.Resources["Primary"];
            var reasonConfig = new ReasonConfigService();

            var lstReasonCheckBox = reasonConfig.Config.ListReason
                .Find(reason => reason.Point == RatingPoint)
                .Values
                .Select(reason => new MaterialCheckbox
                {
                    Animation = Plugin.MaterialDesignControls.AnimationTypes.None,
                    Text = reason,
                    Color = primaryColor,
                    TextColor = primaryColor,
                }).ToList();

            lstReasonCheckBox.ForEach(checkBox => MainContent.Children.Add(checkBox));
        }
    }
}