using System.Net.Http.Headers;

namespace PlantAPI.Helpers;

public static class ApiHelper
{
    public static async Task<AstronomyPictureOfTheDay> GetAstronomyPictureOfTheDay()
    {
        var uri = ("https://api.nasa.gov/planetary/apod?api_key=XySfp6ledMV8Pb472Hyc0inAi8ekYcPGifqb7NMK");

        HttpClient client = new HttpClient();

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.GetAsync(uri);

        return await response.Content.ReadFromJsonAsync<AstronomyPictureOfTheDay>();
    }
}