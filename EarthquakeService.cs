using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Get_data
{
    // Model classes for earthquake data with non-nullable types


    public class Gempa{
        [JsonPropertyName("Tanggal")]
        public string Tanggal { get; set; } = string.Empty;

        [JsonPropertyName("Jam")]
        public string Jam { get; set; } = string.Empty;

        [JsonPropertyName("DateTime")]
        public string DateTime { get; set; } = string.Empty;

        [JsonPropertyName("Coordinates")]
        public string Coordinates { get; set; } = string.Empty;

        [JsonPropertyName("Lintang")]
        public string Lintang { get; set; } = string.Empty;

        [JsonPropertyName("Bujur")]
        public string Bujur { get; set; } = string.Empty;

        [JsonPropertyName("Magnitude")]
        public string Magnitude { get; set; } = string.Empty;

        [JsonPropertyName("Kedalaman")]
        public string Kedalaman { get; set; } = string.Empty;

        [JsonPropertyName("Wilayah")]
        public string Wilayah { get; set; } = string.Empty;

        [JsonPropertyName("Potensi")]
        public string Potensi { get; set; } = string.Empty;

        [JsonPropertyName("Dirasakan")]
        public string Dirasakan { get; set; } = string.Empty;

        [JsonPropertyName("Shakemap")]
        public string Shakemap { get; set; } = string.Empty;
    }

    public class Infogempa
    {
        public Gempa Gempa { get; set; } = new Gempa();
    }

    public class EarthquakeResponse
    {
        public Infogempa Infogempa { get; set; } = new Infogempa();
    }

    // Service class to fetch earthquake data
    public class EarthquakeService
    {
        public async Task<Gempa> FetchEarthquakeData(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Console.WriteLine($"Fetching data from URL: {url}");
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string json_data = await response.Content.ReadAsStringAsync();

                    // Deserialize JSON response into EarthquakeResponse object
                    var earthquakeResponse = JsonSerializer.Deserialize<EarthquakeResponse>(json_data);
                    
                    
                    if (earthquakeResponse == null){
                        Console.WriteLine("Failed to deserialize the response.");
                        return new Gempa(); 
                    }

                    // Check if Infogempa or Gempa is null
                    if (earthquakeResponse.Infogempa == null || earthquakeResponse.Infogempa.Gempa == null){
                        Console.WriteLine("Infogempa or Gempa is null.");
                        return new Gempa(); 
                    }

                    // Return the Gempa object that contains the details
                    return earthquakeResponse.Infogempa.Gempa;

                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                    return new Gempa(); // Return an empty non-null Gempa object in case of an error
                }
            }
        }
    }
}
