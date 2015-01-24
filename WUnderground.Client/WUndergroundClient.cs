using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WUnderground.Client.Models;

namespace WUnderground.Client
{
    /// <summary>
    /// The client object to access the WUnderground API
    /// </summary>
    public class WUndergroundClient
    {
        private const string GeolookupAndCurrentConditionsUri = "http://api.wunderground.com/api/{0}/geolookup/conditions/q/{1},{2}.json";
        private const string GeolookupCurrentConditionsAndForecastUri = "http://api.wunderground.com/api/{0}/geolookup/conditions/forecast/q/{1},{2}.json";
        private const string GeolookupHourlyForecastUri = "http://api.wunderground.com/api/27d9503963b27155/geolookup/hourly/q/{1},{2}.json";

        /// <summary>
        /// Gets the current conditions for the specified coordinates
        /// </summary>
        /// <param name="lat">The latitude</param>
        /// <param name="lng">The longitude</param>
        /// <returns>The response object</returns>
        public static async Task<Response> GetConditionsForLocation(double lat, double lng)
        {
            string uri = string.Format(GeolookupAndCurrentConditionsUri, Config.ApiKey, lat, lng);

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    Response weatherResponse = JsonConvert.DeserializeObject<Response>(content);

                    if (weatherResponse.response.error != null)
                        throw new WUndergroundException(weatherResponse.response.error.description);

                    return weatherResponse;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the current conditions and forecast of the specified coordinates
        /// </summary>
        /// <param name="lat">The latitude</param>
        /// <param name="lng">The longitude</param>
        /// <returns>The response object</returns>
        public static async Task<Response> GetConditionsAndForecastForLocation(double lat, double lng)
        {
            string uri = string.Format(GeolookupCurrentConditionsAndForecastUri, Config.ApiKey, lat, lng);

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    Response weatherResponse = JsonConvert.DeserializeObject<Response>(content);

                    return weatherResponse;
                }
            }
            return null;
        }

        /// <summary>
        /// The configuration for the WUnderground Client
        /// </summary>
        public static class Config
        {
            /// <summary>
            /// The API Key for the WUnderground API. Get yours at http://www.wunderground.com
            /// </summary>
            public static string ApiKey { get; set; }
        }
    }

    public class WUndergroundException : Exception
    {
        public WUndergroundException(string message) : base(message) { }
    }
}
