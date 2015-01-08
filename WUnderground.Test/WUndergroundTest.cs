using System.Configuration;
using System.Diagnostics;
using WUnderground.Client.Models;

namespace WUnderground.Test
{
    class WUndergroundTest
    {
        static void Main(string[] args)
        {
            //Configure the client by setting the API Key. Get yours at http://www.wunderground.com
            WUnderground.Client.WUndergroundClient.Config.ApiKey = ConfigurationSettings.AppSettings["ApiKey"];
            WUnderground.Client.WUndergroundClient client = new WUnderground.Client.WUndergroundClient();

            //Get the current weather conditions for the specified location
            Response current = client.GetConditionsForLocation(51.4800, 0.0).Result;
            Debug.WriteLine(current.current_observation.feelslike_string);

            //Get the weather forecast for the specified location
            Response forecast = client.GetConditionsAndForecastForLocation(51.4800, 0.0).Result;
            Debug.WriteLine(forecast.forecast.txt_forecast.forecastday[0].fcttext);
        }
    }
}
