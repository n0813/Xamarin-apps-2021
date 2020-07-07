using System;
namespace Clima_Xamarin.Models
{

    public class WeatherData
    {
        public Datum[] Data { get; set; }
        public long Count { get; set; }
    }

    public class Datum
    {
        public string WindCdir { get; set; }
        public long Rh { get; set; }
        public string Pod { get; set; }
        public double Pres { get; set; }
        public string Timezone { get; set; }
        public string ObTime { get; set; }
        public string CountryCode { get; set; }
        public long Clouds { get; set; }
        public long Ts { get; set; }
        public double SolarRad { get; set; }
        public long StateCode { get; set; }
        public string city_name { get; set; }
        public double WindSpd { get; set; }
        public DateTimeOffset LastObTime { get; set; }
        public string WindCdirFull { get; set; }
        public double Slp { get; set; }
        public double Vis { get; set; }
        public long Lon { get; set; }
        public double Uv { get; set; }
        public string Datetime { get; set; }
        public long HAngle { get; set; }
        public double Dewpt { get; set; }
        public object Aqi { get; set; }
        public double Dhi { get; set; }
        public long WindDir { get; set; }
        public double ElevAngle { get; set; }
        public double Ghi { get; set; }
        public object Precip { get; set; }
        public string Sunrise { get; set; }
        public long Lat { get; set; }
        public Weather Weather { get; set; }
        public string Sunset { get; set; }
        public double Temp { get; set; }
        public double Dni { get; set; }
        public string Station { get; set; }
        public double AppTemp { get; set; }
    }

    public class Weather
    {
        public string Icon { get; set; }
        public long Code { get; set; }
        public string Description { get; set; }
    }
}