using CRS.Models;
using Plugin.MaterialDesignControls.Material3;
using Plugin.MaterialDesignControls.Material3.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRS.Views.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyRatingIcon : ContentView
    {
        bool isSelected;
        public bool IsSelected {
            get => isSelected;
            set
            {
                isSelected = value;
                Icon = SelectedIcon;
            }
        }
        public string SelectedIcon { get; set; }
        public string UnSelectedIcon { get; set; }

        static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(MyRatingIcon), default(string));
        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        static readonly BindableProperty LabelProperty =
            BindableProperty.Create(nameof(Label), typeof(string), typeof(MyRatingIcon), default(string));
        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public MyRatingIcon()
        {
            InitializeComponent();

            IsSelected = false;
            Icon = UnSelectedIcon;
            iconButton.SetBinding(Image.SourceProperty, new Binding(nameof(Icon), source: this));
            labelIcon.SetBinding(MaterialLabel.TextProperty, new Binding(nameof(Label), source: this));
        }
    }
}