using System.Diagnostics;
using WUnderground.Client;
using WUnderground.Client.Models;

namespace WUnderground.Test
{
    class WUndergroundTest
    {
        static void Main(string[] args)
        {
            //Configure the client by setting the API Key. Get yours at http://www.wunderground.com
            WUndergroundClient.Config.ApiKey = Properties.Settings.Default.ApiKey;
            WUndergroundClient.Config.PROXY_HOST = Properties.Settings.Default.ProxyHost;
            WUndergroundClient.Config.PROXY_PASS = Properties.Settings.Default.ProxyPassword;
            WUndergroundClient.Config.PROXY_USER = Properties.Settings.Default.ProxyUsername;

            //Get the current weather conditions for the specified location
            WeatherResponse current = WUndergroundClient.GetConditionsForLocationAsync(51.4800, 0.0).Result;
            Debug.WriteLine(current.current_observation.feelslike_string);

            //Get the weather forecast for the specified location
            WeatherResponse forecast = WUndergroundClient.GetConditionsAndForecastForLocationAsync(51.4800, 0.0).Result;
            Debug.WriteLine(forecast.forecast.txt_forecast.forecastday[0].fcttext);

            //Get the weather forecast for the specified location
            Observation observation = WUndergroundClient.GetHistoricObservationForLocationAsync(new System.DateTime(2015,12,01,12,10,10),51.4800, 0.0).Result;
            Debug.WriteLine(observation.conds);
        }
    }
}
