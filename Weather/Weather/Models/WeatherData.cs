using System;
namespace Weather.Models
{

    public partial class WeatherData
    {
        public Datum[] Data { get; set; }
        public long Count { get; set; }
    }

    public partial class Datum
    {
        public long Rh { get; set; }
        public string Pod { get; set; }
        public double Lon { get; set; }
        public long Pres { get; set; }
        public string Timezone { get; set; }
        public string ObTime { get; set; }
        public string CountryCode { get; set; }
        public long Clouds { get; set; }
        public long Ts { get; set; }
        public double SolarRad { get; set; }
        public long StateCode { get; set; }
        public string city_name { get; set; }
        public long WindSpd { get; set; }
        public string WindCdirFull { get; set; }
        public string WindCdir { get; set; }
        public long Slp { get; set; }
        public long Vis { get; set; }
        public double HAngle { get; set; }
        public string Sunset { get; set; }
        public double Dni { get; set; }
        public double Dewpt { get; set; }
        public long Snow { get; set; }
        public double Uv { get; set; }
        public long Precip { get; set; }
        public long WindDir { get; set; }
        public string Sunrise { get; set; }
        public double Ghi { get; set; }
        public double Dhi { get; set; }
        public long Aqi { get; set; }
        public double Lat { get; set; }
        public Weather Weather { get; set; }
        public string Datetime { get; set; }
        public double Temp { get; set; }
        public string Station { get; set; }
        public double ElevAngle { get; set; }
        public long AppTemp { get; set; }
    }

    public partial class Weather
    {
        public string Icon { get; set; }
        public long Code { get; set; }
        public string Description { get; set; }
    }


}
