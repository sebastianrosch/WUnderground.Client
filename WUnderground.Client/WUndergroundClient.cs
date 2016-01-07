using MoreLinq;
using System;
using System.Net;
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
        private const string GeolookupHistoryUri = "http://api.wunderground.com/api/{0}/history_{3}/geolookup/q/{1},{2}.json";

        private static async Task<WeatherResponse> GetResponse(Uri m_uri)
        {
            dynamic client = new RestSharp.Portable.HttpClient.RestClient
            {
                Proxy = Config.getWebProxy(),
                BaseUrl = m_uri
            };

            dynamic request = new RestSharp.Portable.RestRequest();

            dynamic response = await client.Execute<WeatherResponse>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                WeatherResponse weatherResponse = response.Data;

                if (weatherResponse.response.error != null)
                {
                    throw new WUndergroundException(weatherResponse.response.error.description);
                }

                return weatherResponse;
            }
            else
            {
                throw new WUndergroundException(response.Content);
            }
        }

        /// <summary>
        /// Gets the current conditions for the specified coordinates
        /// </summary>
        /// <param name="lat">The latitude</param>
        /// <param name="lng">The longitude</param>
        /// <returns>The response object</returns>
        public static async Task<WeatherResponse> GetConditionsForLocationAsync(double lat, double lng)
        {
            Uri m_uri = new Uri(string.Format(GeolookupAndCurrentConditionsUri, Config.ApiKey, lat, lng));
            return await GetResponse(m_uri);
        }

        /// <summary>
        /// Gets the current conditions and forecast of the specified coordinates
        /// </summary>
        /// <param name="lat">The latitude</param>
        /// <param name="lng">The longitude</param>
        /// <returns>The response object</returns>
        public static async Task<WeatherResponse> GetConditionsAndForecastForLocationAsync(double lat, double lng)
        {
            Uri m_uri = new Uri(string.Format(GeolookupCurrentConditionsAndForecastUri, Config.ApiKey, lat, lng));
            return await GetResponse(m_uri);
        }

        /// <summary>
        /// Gets the historic conditions for the specified coordinates and datetime
        /// </summary>
        /// <param name="dat">The date</param>
        /// <param name="lat">The latitude</param>
        /// <param name="lng">The longitude</param>
        /// <returns>The response object</returns>
        public static async Task<Observation> GetHistoricObservationForLocationAsync(DateTime dat, double lat, double lng)
        {
            string dat_uri = dat.ToString("yyyyMMdd");
            Uri m_uri = new Uri(string.Format(GeolookupHistoryUri, Config.ApiKey, lat, lng, dat_uri));
            WeatherResponse response = await GetResponse(m_uri);

            var closest_observation = response.history.observations.MinBy(n => Math.Abs((n.dateTime - dat).Ticks));

            return closest_observation;
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

            /// <summary>
            /// The username for authentication with the webproxy
            /// </summary>
            public static string PROXY_USER { get; set; }

            /// <summary>
            /// The password for authentication with the webproxy
            /// </summary>
            public static string PROXY_PASS { get; set; }

            /// <summary>
            /// The host for the webproxy
            /// </summary>
            public static string PROXY_HOST { get; set; }

            /// <summary>
            /// The port used by the webproxy
            /// </summary>
            public static int PROXY_PORT { get; set; }

            /// <summary>
            /// Get the webproxy client
            /// </summary>
            /// <returns>Webproxy client</returns>
            public static Proxy getWebProxy()
            {
                NetworkCredential cred = new NetworkCredential(Config.PROXY_USER, Config.PROXY_PASS);

                dynamic proxy = new Proxy(new Uri(Config.PROXY_HOST));
                proxy.Credentials = cred;

                return proxy;
            }
            public class Proxy : RestSharp.Portable.IRequestProxy
            {
                public System.Net.ICredentials Credentials
                {
                    get;
                    set;
                }

                private readonly Uri _proxyUri;

                public Proxy(Uri proxyUri)
                {
                    _proxyUri = proxyUri;
                }

                public Uri GetProxy(Uri destination)
                {
                    return _proxyUri;
                }

                public bool IsBypassed(Uri host)
                {
                    return false;
                }
            }
        }
    }

    /// <summary>
    /// An exception thrown by the WUnderground service
    /// </summary>
    public class WUndergroundException : Exception
    {
        /// <summary>
        /// Creates a new WUnderground exception with the specified message
        /// </summary>
        /// <param name="message">The message</param>
        public WUndergroundException(string message) : base(message) { }
    }
}
