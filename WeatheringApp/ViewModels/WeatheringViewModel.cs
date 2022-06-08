using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Weathering.Services;
using WeatheringApp.Models.Service;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatheringApp.ViewModels
{
    public class WeatheringViewModel : ViewModelBase
    {

        private OpenWeatherData _weather;

        public OpenWeatherData Weather
        {
            get { return _weather; }
            set
            {
                _weather = value;
                OnPropertyChanged();
            }
        }

        private ICommand _newWeatherCommand;
        public ICommand NewWeatherCommand =>
            _newWeatherCommand ?? (_newWeatherCommand = new Command(PersistedWeatherCommand));


       public async void PersistedWeatherCommand()
        {
            await GetPersistedWeather();
        }

        public async Task GetPersistedWeather()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.None)
            {
                var remoteServer = new WeatheringService();

                var weather = await remoteServer.GetOpenWeather();

                Weather = weather;
                Models.Weather dbWeather = new Models.Weather();
                dbWeather.Date = DateTime.Now;
               // dbWeather.Weather = weather.weather;
               // var database = WeatheringDatabase.Instance;

                //database.SaveWeather(dbWeather);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Internet", "Connectivity not available.", "Ok");
            }
        }
    }
}
