using System.Collections.Generic;
using WeatheringApp.Models;
using WeatheringApp.Services;

namespace WeatheringApp.ViewModels
{
    public class WeatheringHistoryViewModel : ViewModelBase
    {
        private List<Weather> _weathering;


        public List<Weather> weathering
        {
            get { return _weathering; }
            set
            {
                _weathering = value;
                OnPropertyChanged();
            }
        }

        public void Refresh()
        {
               var database = WeatheringDatabase.Instance;
              weathering = database.GetWeather();
        }


    }
}
