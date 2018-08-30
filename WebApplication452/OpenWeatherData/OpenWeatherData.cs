using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace OpenWeather
{
    public interface IWeatherData
    {
        WeatherData GetWeatherData(out string error);
    }
    public class OpenWeatherData : IWeatherData
    {
        private string url = @"http://api.openweathermap.org/data/2.5/weather?id=4881346&APPID=81e83a741cca81a9dbc7d2c4f3218e8a";
        public WeatherData GetWeatherData(out string error)
        {
            WeatherData weatherData = null;
            error = string.Empty;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();
                var resStream = response.GetResponseStream();

                var stringResult = new StreamReader(resStream).ReadToEnd().Replace("base", "base1"); // can't use "base" as variable name
                //string test = "{\"coord\":{\"lon\":-93.75,\"lat\":41.57},\"weather\":[{\"id\":502,\"main\":\"Rain\",\"description\":\"heavy intensity rain\",\"icon\":\"10n\"},{\"id\":300,\"main\":\"Drizzle\",\"description\":\"light intensity drizzle\",\"icon\":\"09n\"}],\"base1\":\"stations\",\"main\":{\"temp\":292.57,\"pressure\":1012,\"humidity\":90,\"temp_min\":289.15,\"temp_max\":295.15},\"visibility\":16093,\"wind\":{\"speed\":7.2,\"deg\":330,\"gust\":11.8},\"rain\":{\"1h\":0.25},\"clouds\":{\"all\":90},\"dt\":1535506500,\"sys\":{\"type\":1,\"id\":865,\"message\":0.0041,\"country\":\"US\",\"sunrise\":1535542689,\"sunset\":1535590368},\"id\":4881346,\"name\":\"West Des Moines\",\"cod\":200}";

                weatherData = new JavaScriptSerializer().Deserialize<WeatherData>(stringResult);
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return weatherData;
        }
    }

    public class Coord
    {
        public double lon;
        public double lat;
    }
    public class Weather
    {
        public int id;
        public string main;
        public string description;
        public string icon;
    }
    public class MainData
    {
        public double temp;
        public double pressure;
        public double humidity;
        public double temp_min;
        public double temp_max;
    }
    public class Wind
    {
        public double speed;
        public double deg;
        public double gust;
    }
    public class Rain
    {
        public double _1h;
    }
    public class Clouds
    {
        public int all;
    }
    public class Sys
    {
        public int type;
        public int id;
        public double message;
        public string country;
        public long sunrise;
        public long sunset;
    }
    public class WeatherData
    {
        public Coord coord;
        public Weather[] weather;
        public string base1;
        public MainData main;
        public long visibility;
        public Wind wind;
        public Rain rain;
        public Clouds clouds;
        public long dt;
        public Sys sys;
        public long id;
        public string name;
        public int cod;
    }


}
