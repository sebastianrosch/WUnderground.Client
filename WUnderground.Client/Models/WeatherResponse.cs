using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUnderground.Client.Models
{
    public class Features
    {
        public int geolookup { get; set; }
        public int conditions { get; set; }
        public int forecast { get; set; }
        public int hourly { get; set; }
    }

    public class ResponseMetadata
    {
        public string version { get; set; }
        public string termsofService { get; set; }
        public Features features { get; set; }
        public Error error { get; set; }
    }

    public class Error
    {
        public string type { get; set; }
        public string description { get; set; }
    }

    public class Station
    {
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string icao { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string neighborhood { get; set; }
        public string id { get; set; }
        public int distance_km { get; set; }
        public int distance_mi { get; set; }
    }

    public class Airport
    {
        public List<Station> station { get; set; }
    }

    public class Pws
    {
        public List<Station> station { get; set; }
    }

    public class NearbyWeatherStations
    {
        public Airport airport { get; set; }
        public Pws pws { get; set; }
    }

    public class Location
    {
        public string type { get; set; }
        public string country { get; set; }
        public string country_iso3166 { get; set; }
        public string country_name { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string tz_short { get; set; }
        public string tz_long { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string zip { get; set; }
        public string magic { get; set; }
        public string wmo { get; set; }
        public string l { get; set; }
        public string requesturl { get; set; }
        public string wuiurl { get; set; }
        public NearbyWeatherStations nearby_weather_stations { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
        public string title { get; set; }
        public string link { get; set; }
    }

    public class DisplayLocation
    {
        public string full { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string state_name { get; set; }
        public string country { get; set; }
        public string country_iso3166 { get; set; }
        public string zip { get; set; }
        public string magic { get; set; }
        public string wmo { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string elevation { get; set; }
    }

    public class ObservationLocation
    {
        public string full { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string country_iso3166 { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string elevation { get; set; }
    }

    public class Estimated
    {
    }

    public class CurrentObservation
    {
        public Image image { get; set; }
        public DisplayLocation display_location { get; set; }
        public ObservationLocation observation_location { get; set; }
        public Estimated estimated { get; set; }
        public string station_id { get; set; }
        public string observation_time { get; set; }
        public string observation_time_rfc822 { get; set; }
        public string observation_epoch { get; set; }
        public string local_time_rfc822 { get; set; }
        public string local_epoch { get; set; }
        public string local_tz_short { get; set; }
        public string local_tz_long { get; set; }
        public string local_tz_offset { get; set; }
        public string weather { get; set; }
        public string temperature_string { get; set; }
        public double temp_f { get; set; }
        public double temp_c { get; set; }
        public string relative_humidity { get; set; }
        public string wind_string { get; set; }
        public string wind_dir { get; set; }
        public int wind_degrees { get; set; }
        public double wind_mph { get; set; }
        public string wind_gust_mph { get; set; }
        public double wind_kph { get; set; }
        public string wind_gust_kph { get; set; }
        public string pressure_mb { get; set; }
        public string pressure_in { get; set; }
        public string pressure_trend { get; set; }
        public string dewpoint_string { get; set; }
        public int dewpoint_f { get; set; }
        public int dewpoint_c { get; set; }
        public string heat_index_string { get; set; }
        public string heat_index_f { get; set; }
        public string heat_index_c { get; set; }
        public string windchill_string { get; set; }
        public string windchill_f { get; set; }
        public string windchill_c { get; set; }
        public string feelslike_string { get; set; }
        public string feelslike_f { get; set; }
        public string feelslike_c { get; set; }
        public string visibility_mi { get; set; }
        public string visibility_km { get; set; }
        public string solarradiation { get; set; }
        public string UV { get; set; }
        public string precip_1hr_string { get; set; }
        public string precip_1hr_in { get; set; }
        public string precip_1hr_metric { get; set; }
        public string precip_today_string { get; set; }
        public string precip_today_in { get; set; }
        public string precip_today_metric { get; set; }
        public string icon { get; set; }
        public string icon_url { get; set; }
        public string forecast_url { get; set; }
        public string history_url { get; set; }
        public string ob_url { get; set; }
        public string nowcast { get; set; }
    }

    public class Forecastday
    {
        public int period { get; set; }
        public string icon { get; set; }
        public string icon_url { get; set; }
        public string title { get; set; }
        public string fcttext { get; set; }
        public string fcttext_metric { get; set; }
        public string pop { get; set; }
        public Date date { get; set; }
        public Temperature high { get; set; }
        public Temperature low { get; set; }
        public string conditions { get; set; }
        public string skyicon { get; set; }
        public Precipitation qpf_allday { get; set; }
        public Precipitation qpf_day { get; set; }
        public Precipitation qpf_night { get; set; }
        public Precipitation snow_allday { get; set; }
        public Precipitation snow_day { get; set; }
        public Precipitation snow_night { get; set; }
        public Wind maxwind { get; set; }
        public Wind avewind { get; set; }
        public int avehumidity { get; set; }
        public int maxhumidity { get; set; }
        public int minhumidity { get; set; }
    }

    public class HourlyForecast
    {
        public Time FCTTIME { get; set; }
        public TemperatureOrPrecipitation temp { get; set; }
        public TemperatureOrPrecipitation dewpoint { get; set; }
        public string condition { get; set; }
        public string icon { get; set; }
        public string icon_url { get; set; }
        public string fctcode { get; set; }
        public string sky { get; set; }
        public TemperatureOrPrecipitation wspd { get; set; }
        public WindDirection wdir { get; set; }
        public string wx { get; set; }
        public string uvi { get; set; }
        public string humidity { get; set; }
        public TemperatureOrPrecipitation windchill { get; set; }
        public TemperatureOrPrecipitation heatindex { get; set; }
        public TemperatureOrPrecipitation feelslike { get; set; }
        public TemperatureOrPrecipitation qpf { get; set; }
        public TemperatureOrPrecipitation snow { get; set; }
        public string pop { get; set; }
        public TemperatureOrPrecipitation mslp { get; set; }
    }

    public class TxtForecast
    {
        public string date { get; set; }
        public List<Forecastday> forecastday { get; set; }
    }

    public class Time
    {
        public string hour { get; set; }
        public string hour_padded { get; set; }
        public string min { get; set; }
        public string min_unpadded { get; set; }
        public string sec { get; set; }
        public string year { get; set; }
        public string mon { get; set; }
        public string mon_padded { get; set; }
        public string mon_abbrev { get; set; }
        public string mday { get; set; }
        public string mday_padded { get; set; }
        public string yday { get; set; }
        public string isdst { get; set; }
        public string epoch { get; set; }
        public string pretty { get; set; }
        public string civil { get; set; }
        public string month_name { get; set; }
        public string month_name_abbrev { get; set; }
        public string weekday_name { get; set; }
        public string weekday_name_night { get; set; }
        public string weekday_name_abbrev { get; set; }
        public string weekday_name_unlang { get; set; }
        public string weekday_name_night_unlang { get; set; }
        public string ampm { get; set; }
        public string tz { get; set; }
        public string age { get; set; }
        public string UTCDATE { get; set; }
    }

    public class Date
    {
        public string epoch { get; set; }
        public string pretty { get; set; }
        public int mday { get; set; }
        public int mon { get; set; }
        public int year { get; set; }
        public int yday { get; set; }
        public int hour { get; set; }
        public int min { get; set; }
        public int sec { get; set; }
        public string isdst { get; set; }
        public string monthname { get; set; }
        public string monthname_short { get; set; }
        public string weekday_short { get; set; }
        public string weekday { get; set; }
        public string ampm { get; set; }
        public string tz_short { get; set; }
        public string tz_long { get; set; }
    }

    public class Temperature
    {
        public string fahrenheit { get; set; }
        public string celsius { get; set; }
    }

    public class TemperatureOrPrecipitation
    {
        public string english { get; set; }
        public string metric { get; set; }
    }

    public class Precipitation
    {
        public double? @in { get; set; }
        public double? mm { get; set; }
    }

    public class WindDirection
    {
        public string dir { get; set; }
        public string degrees { get; set; }
    }

    public class Wind
    {
        public double mph { get; set; }
        public double kph { get; set; }
        public string dir { get; set; }
        public double degrees { get; set; }
    }

    public class Simpleforecast
    {
        public List<Forecastday> forecastday { get; set; }
    }

    public class Forecast
    {
        public TxtForecast txt_forecast { get; set; }
        public Simpleforecast simpleforecast { get; set; }
    }

    public class WeatherResponse
    {
        public ResponseMetadata response { get; set; }
        public Location location { get; set; }
        public CurrentObservation current_observation { get; set; }
        public Forecast forecast { get; set; }
        public List<HourlyForecast> hourly_forecast { get; set; }
        public History history { get; set; }
    }

    public class History
    {
        public Date date { get; set; }
        public Date utcdate { get; set; }
        public List<Observation> observations { get; set; }
        public List<DailySummary> dailysummary { get; set; }
    }

    public class Observation
    {
        public Date date { get; set; }
        public Date utcdate { get; set; }
        public double? tempm { get; set; }
        public double? tempi { get; set; }
        public double? dewptm { get; set; }
        public double? dewpti { get; set; }
        public int hum { get; set; }
        public double? wspdm { get; set; }
        public double? wspdi { get; set; }
        public double? wgustm { get; set; }
        public double? wgusti { get; set; }
        public int wdird { get; set; }
        public string wdire { get; set; }
        public double? vism { get; set; }
        public double? visi { get; set; }
        public double? pressurem { get; set; }
        public double? pressurei { get; set; }
        public double? windchillm { get; set; }
        public double? windchilli { get; set; }
        public double? heatindexm { get; set; }
        public double? heatindexi { get; set; }
        public double? precipm { get; set; }
        public double? precipi { get; set; }
        public string conds { get; set; }
        public string icon { get; set; }
        public int fog { get; set; }
        public int rain { get; set; }
        public int snow { get; set; }
        public int hail { get; set; }
        public int thunder { get; set; }
        public int tornado { get; set; }
        public string metar { get; set; }

        public DateTime dateTime
        {
            get { return new DateTime(utcdate.year, utcdate.mon, utcdate.mday, utcdate.hour, utcdate.min,utcdate.sec); }
        }
    }

    public class DailySummary
    {
        public Date date { get; set; }
        public int fog { get; set; }
        public int rain { get; set; }
        public int snow { get; set; }
        public double? snowfallm { get; set; }
        public double? snowfalli { get; set; }
        public double? monthtodatesnowfallm { get; set; }
        public double? monthtodatesnowfalli { get; set; }
        public double? since1julsnowfallm { get; set; }
        public double? since1julsnowfalli { get; set; }
        public double? snowdepthm { get; set; }
        public double? snowdepthi { get; set; }
        public int hail { get; set; }
        public int thunder { get; set; }
        public int tornado { get; set; }
        public double? meantempm { get; set; }
        public double? meantempi { get; set; }
        public double? meandewptm { get; set; }
        public double? meandewpti { get; set; }
        public double? meanpressurem { get; set; }
        public double? meanpressurei { get; set; }
        public double? meanwindspdm { get; set; }
        public double? meanwindspdi { get; set; }
        public string meanwdire { get; set; }
        public double? meanwdird { get; set; }
        public double? meanvism { get; set; }
        public double? meanvisi { get; set; }
        public double? humidity { get; set; }
        public double? maxtempm { get; set; }
        public double? maxtempi { get; set; }
        public double? mintempm { get; set; }
        public double? mintempi { get; set; }
        public double? maxhumidity { get; set; }
        public double? minhumidity { get; set; }
        public double? maxdewptm { get; set; }
        public double? maxdewpti { get; set; }
        public double? mindewptm { get; set; }
        public double? mindewpti { get; set; }
        public double? maxpressurem { get; set; }
        public double? maxpressurei { get; set; }
        public double? minpressurem { get; set; }
        public double? minpressurei { get; set; }
        public double? maxwspdm { get; set; }
        public double? maxwspdi { get; set; }
        public double? minwspdm { get; set; }
        public double? minwspdi { get; set; }
        public double? maxvism { get; set; }
        public double? maxvisi { get; set; }
        public double? minvism { get; set; }
        public double? minvisi { get; set; }
        public double? gdegreedays { get; set; }
        public double? heatingdegreedays { get; set; }
        public double? coolingdegreedays { get; set; }
        public double? precipm { get; set; }
        public double? precipi { get; set; }
        public string precipsource { get; set; }
        public int? heatingdegreedaysnormal { get; set; }
        public int? monthtodateheatingdegreedays { get; set; }
        public int? monthtodateheatingdegreedaysnormal { get; set; }
        public int? since1sepheatingdegreedays { get; set; }
        public int? since1sepheatingdegreedaysnormal { get; set; }
        public int? since1julheatingdegreedays { get; set; }
        public int? since1julheatingdegreedaysnormal { get; set; }
        public int? coolingdegreedaysnormal { get; set; }
        public int? monthtodatecoolingdegreedays { get; set; }
        public int? monthtodatecoolingdegreedaysnormal { get; set; }
        public int? since1sepcoolingdegreedays { get; set; }
        public int? since1sepcoolingdegreedaysnormal { get; set; }
        public int? since1jancoolingdegreedays { get; set; }
        public int? since1jancoolingdegreedaysnormal { get; set; }
    }
}
