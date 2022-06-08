using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatheringApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatheringApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatheringHistoryView : ContentPage
    {
       
        public WeatheringHistoryView()
        {
            InitializeComponent();

            BindingContext = new WeatheringHistoryViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as WeatheringHistoryViewModel;

            vm.Refresh();
        }
    }
}