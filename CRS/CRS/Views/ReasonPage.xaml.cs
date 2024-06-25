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
using static CRS.Utilities.Constant;

namespace CRS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReasonPage : BasePage
    {
        public ReasonPage()
        {
            InitializeComponent();
            this.BindingContext = new ReasonViewModel();

            Color primaryColor = (Color)Application.Current.Resources["Primary"];
            var reasonConfig = new ReasonConfigService();
            var lstReasonCheckBox = reasonConfig.Config.ListReason
                .Find(reason => reason.Point == RatingPoint.Sad)
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