using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.UI;

public class GetCurrentWeatherInfo : MonoBehaviour
{
    const string URL_GetPublicIP = "https://api.ipify.org/";
    const string URL_GetGeographicData = "http://www.geoplugin.net/json.gp?ip=";
    const string URL_GetWeatherData = "http://api.openweathermap.org/data/2.5/weather";

    #region weather api key
    const string apiKey = "ddc441a6f25d5cd3c70a5a90d50a813e";
    #endregion

    public enum Ephase
    {
        NotStarted,
        GetPublicIP,
        GetGeographicData,
        GetWeatherData,

        Failed,
        Succeeded
    }

    class geoPluginResponse
    {
        [JsonProperty("geoplugin_request")] public string Request { get; set; }
        [JsonProperty("geoplugin_status")] public int Status { get; set; }
        [JsonProperty("geoplugin_delay")] public string Delay { get; set; }
        [JsonProperty("geoplugin_credit")] public string Credit { get; set; }
        [JsonProperty("geoplugin_city")] public string City { get; set; }
        [JsonProperty("geoplugin_region")] public string Region { get; set; }
        [JsonProperty("geoplugin_regionCode")] public string RegionCode { get; set; }
        [JsonProperty("geoplugin_regionName")] public string RegionName { get; set; }
        [JsonProperty("geoplugin_areaCode")] public string AreaCode { get; set; }
        [JsonProperty("geoplugin_dmaCode")] public string DMACode { get; set; }
        [JsonProperty("geoplugin_countryCode")] public string CountryCode { get; set; }
        [JsonProperty("geoplugin_countryName")] public string CountryName { get; set; }
        [JsonProperty("geoplugin_inEU")] public int InEU { get; set; }
        [JsonProperty("geoplugin_euVATrate")] public bool EUVATRate { get; set; }
        [JsonProperty("geoplugin_continentCode")] public string ContinentCode { get; set; }
        [JsonProperty("geoplugin_continentName")] public string ContinentName { get; set; }
        [JsonProperty("geoplugin_latitude")] public string Latitude { get; set; }
        [JsonProperty("geoplugin_longitude")] public string Longitude { get; set; }
        [JsonProperty("geoplugin_locationAccuracyRadius")] public string LocationAccuracyRadius { get; set; }
        [JsonProperty("geoplugin_timezone")] public string TimeZone { get; set; }
        [JsonProperty("geoplugin_currencyCode")] public string CurrencyCode { get; set; }
        [JsonProperty("geoplugin_currencySymbol")] public string CurrencySymbol { get; set; }
        [JsonProperty("geoplugin_currencySymbol_UTF8")] public string CurrencySymbolUTF8 { get; set; }
        [JsonProperty("geoplugin_currencyConverter")] public double CurrencyConverter { get; set; }
    }

    public class OpenWeather_Coordinates
    {
        [JsonProperty("lon")] public double Longitude { get; set; }
        [JsonProperty("lat")] public double Latitude { get; set; }
    }

    // Condition Info: https://openweathermap.org/weather-conditions
    public class OpenWeather_Condition
    {
        [JsonProperty("id")] public int ConditionID { get; set; }
        [JsonProperty("main")] public string Group { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("icon")] public string Icon { get; set; }
    }

    public class OpenWeather_KeyInfo
    {
        [JsonProperty("temp")] public double Temperature { get; set; }
        [JsonProperty("feels_like")] public double Temperature_FeelsLike { get; set; }
        [JsonProperty("temp_min")] public double Temperature_Minimum { get; set; }
        [JsonProperty("temp_max")] public double Temperature_Maximum { get; set; }
        [JsonProperty("pressure")] public int Pressure { get; set; }
        [JsonProperty("sea_level")] public int PressureAtSeaLevel { get; set; }
        [JsonProperty("grnd_level")] public int PressureAtGroundLevel { get; set; }
        [JsonProperty("humidity")] public int Humidity { get; set; }
    }

    public class OpenWeather_Wind
    {
        [JsonProperty("speed")] public double Speed { get; set; }
        [JsonProperty("deg")] public int Direction { get; set; }
        [JsonProperty("gust")] public double Gust { get; set; }
    }

    public class OpenWeather_Clouds
    {
        [JsonProperty("all")] public int Cloudiness { get; set; }
    }

    public class OpenWeather_Rain
    {
        [JsonProperty("1h")] public int VolumeInLastHour { get; set; }
        [JsonProperty("3h")] public int VolumeInLast3Hours { get; set; }
    }

    public class OpenWeather_Snow
    {
        [JsonProperty("1h")] public int VolumeInLastHour { get; set; }
        [JsonProperty("3h")] public int VolumeInLast3Hours { get; set; }
    }

    public class OpenWeather_Internal
    {
        [JsonProperty("type")] public int Internal_Type { get; set; }
        [JsonProperty("id")] public int Internal_ID { get; set; }
        [JsonProperty("message")] public double Internal_Message { get; set; }
        [JsonProperty("country")] public string CountryCode { get; set; }
        [JsonProperty("sunrise")] public int SunriseTime { get; set; }
        [JsonProperty("sunset")] public int SunsetTime { get; set; }
    }

    class OpenWeatherResponse
    {
        [JsonProperty("coord")] public GetCurrentWeatherInfo.OpenWeather_Coordinates Location { get; set; }
        [JsonProperty("weather")] public List<OpenWeather_Condition> WeatherConditions { get; set; }
        [JsonProperty("base")] public string Internal_Base { get; set; }
        [JsonProperty("main")] public OpenWeather_KeyInfo KeyInfo { get; set; }
        [JsonProperty("visibility")] public int Visibility { get; set; }
        [JsonProperty("wind")] public OpenWeather_Wind Wind { get; set; }
        [JsonProperty("clouds")] public OpenWeather_Clouds Clouds { get; set; }
        [JsonProperty("rain")] public OpenWeather_Rain Rain { get; set; }
        [JsonProperty("snow")] public OpenWeather_Snow Snow { get; set; }
        [JsonProperty("dt")] public int TimeOfCalculation { get; set; }
        [JsonProperty("sys")] public OpenWeather_Internal Internal_Sys { get; set; }
        [JsonProperty("timezone")] public int Timezone { get; set; }
        [JsonProperty("id")] public int CityID { get; set; }
        [JsonProperty("name")] public string CityName { get; set; }
        [JsonProperty("cod")] public int Internal_COD { get; set; }
    }


    public Ephase phase { get; private set; } = Ephase.NotStarted;

    string publicIP;
    geoPluginResponse GeographicData;
    OpenWeatherResponse weatherData;
    bool shownWeatherInfo = false;

    public Text text;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetWeather_Stage1_PublicIP());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == Ephase.Succeeded && !shownWeatherInfo)
        {
            shownWeatherInfo = true;

            text.text = $"Temperature: {weatherData.KeyInfo.Temperature} F City Name: {weatherData.CityName}";

            Debug.Log($"Weather Data {weatherData.CityName}");
            Debug.Log($"Temperature: {weatherData.KeyInfo.Temperature}");



            foreach(var conditions in weatherData.WeatherConditions)
            {
                Debug.Log($"conditions: {conditions.Group}: {conditions.Description}");
                FindObjectOfType<Rain>().rainStatus(conditions.Group);
                FindObjectOfType<PotManager>().getSunStatus(conditions.Group);
            }
        }
    }

    IEnumerator GetWeather_Stage1_PublicIP()
    {
        phase = Ephase.GetPublicIP;
        //attempt to retrieve public IP address
        using (UnityWebRequest request = UnityWebRequest.Get(URL_GetPublicIP))
        {
            request.timeout = 1;
            yield return request.SendWebRequest();

            //did the request fail
            if(request.result == UnityWebRequest.Result.Success)
            {
                publicIP = request.downloadHandler.text.Trim();
                StartCoroutine(GetWeather_stage2_GeoInfo());
            }
            else
            {
                Debug.LogError($"Failed to get public IP: {request.downloadHandler.text}");
                phase = Ephase.Failed;
            }

        }

        yield return null;
    }

    IEnumerator GetWeather_stage2_GeoInfo()
    {
        phase = Ephase.GetGeographicData;

        //atempt to retrieve the geographic data
        using (UnityWebRequest request = UnityWebRequest.Get(URL_GetGeographicData + publicIP))
        {
            request.timeout = 1;
            yield return request.SendWebRequest();

            //did the request fail
            if (request.result == UnityWebRequest.Result.Success)
            {
                GeographicData = JsonConvert.DeserializeObject<geoPluginResponse>(request.downloadHandler.text);
                StartCoroutine(GetWeather_Stage3_WeatherInfo());
            }
            else
            {
                Debug.LogError($"Failed to get geographic data: {request.downloadHandler.text}");
                phase = Ephase.Failed;
            }

        }

        yield return null;

    }

    IEnumerator GetWeather_Stage3_WeatherInfo()
    {
        phase = Ephase.GetWeatherData;

        string weatherURL = URL_GetWeatherData;
        weatherURL += $"?lat={GeographicData.Latitude}";
        weatherURL += $"&lon={GeographicData.Longitude}";
        weatherURL += $"&units=imperial";
        weatherURL += $"&APPID={apiKey}";

        //atempt to retrieve the Weather data
        using (UnityWebRequest request = UnityWebRequest.Get(weatherURL))
        {
            request.timeout = 1;
            yield return request.SendWebRequest();

            //did the request fail
            if (request.result == UnityWebRequest.Result.Success)
            {
                weatherData = JsonConvert.DeserializeObject<OpenWeatherResponse>(request.downloadHandler.text);
                phase = Ephase.Succeeded;
            }
            else
            {
                Debug.LogError($"Failed to get Weather data: {request.downloadHandler.text}");
                phase = Ephase.Failed;
            }

        }

        yield return null;
    }
}
