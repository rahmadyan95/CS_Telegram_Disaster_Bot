using System;
using System.Threading.Tasks;

namespace Get_data
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // URL for the earthquake data (replace with the actual API endpoint)
            string url = "https://data.bmkg.go.id/DataMKG/TEWS/autogempa.json"; // Replace with actual URL

            // Create an instance of the EarthquakeService
            EarthquakeService earthquakeService = new EarthquakeService();

            // Fetch earthquake data
            Gempa gempaData = await earthquakeService.FetchEarthquakeData(url);

            Console.WriteLine(gempaData.Tanggal);

            // Display the fetched earthquake data
            Console.WriteLine("Earthquake Data:");
            Console.WriteLine($"Date: {gempaData.Tanggal}");
            Console.WriteLine($"Time: {gempaData.Jam}");
            Console.WriteLine($"Coordinates: {gempaData.Coordinates}");
            Console.WriteLine($"Magnitude: {gempaData.Magnitude}");
            Console.WriteLine($"Depth: {gempaData.Kedalaman}");
            Console.WriteLine($"Region: {gempaData.Wilayah}");
            Console.WriteLine($"Potential: {gempaData.Potensi}");
            Console.WriteLine($"Felt: {gempaData.Dirasakan}");
            Console.WriteLine($"Shakemap: {gempaData.Shakemap}");
        }
    }
}
