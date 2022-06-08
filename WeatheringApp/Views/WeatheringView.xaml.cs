using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatheringApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatheringApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatheringView : ContentPage
    {
        public WeatheringView()
        {
            InitializeComponent();

            BindingContext = new WeatheringViewModel();

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as WeatheringViewModel;

            vm.NewWeatherCommand.Execute(null);

        }
    }
}