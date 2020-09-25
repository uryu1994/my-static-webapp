using System;
using System.Collections.Generic;
using System.Xml;

namespace my_static_webapp_domain
{
    public class WeatherForecast
    {
        public WeatherForecast()
        {
        }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    public static class WeatherForecastExtensions
    {
        public static void Add(this List<WeatherForecast> list, DateTime date, int temperature_c, string summary)
        {
            list.Add(new WeatherForecast
            {
                Date = date,
                TemperatureC = temperature_c,
                Summary = summary
            });
        }
    }
}
