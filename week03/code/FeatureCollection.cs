using Newtonsoft.Json;

public class FeatureCollection

{
        public List<Feature> Features { get; set; }
}
public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public string Place { get; set; }
    public double Mag { get; set; }
}
public class EarthquakeData
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<List<string>> EarthquakeDailySummary()
     {
        string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        var response = await client.GetStringAsync(url);
        var earthquakeData = JsonConvert.DeserializeObject<FeatureCollection>(response);

        var result = new List<string>();
        foreach (var feature in earthquakeData.Features)
        {
            string formattedString = $"{feature.Properties.Place} - Mag {feature.Properties.Mag}";
            result.Add(formattedString);
        }
               return result;
    }
}    
