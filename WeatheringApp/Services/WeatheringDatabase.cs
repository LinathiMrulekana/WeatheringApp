using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using WeatheringApp.Models;

namespace WeatheringApp.Services
{
    public class WeatheringDatabase
    {
        private SQLiteConnection _database;

        public static WeatheringDatabase Instance = new WeatheringDatabase();

        public WeatheringDatabase()
        {
            ///
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = path + "weather.db";

            _database = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);

            _database.CreateTable<Weather>();
        }

        public List<Weather> GetWeather()
        {
            return _database.Table<Weather>().OrderByDescending(x => x.Date).ToList();
        }

        public void SaveWeather(Weather weather)
        {
            _database.Insert(weather);
        }
    }
}
