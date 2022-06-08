using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WeatheringApp.Models
{
    public  class Weather
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public double Temp { get; set; }

    }
}
