using System.Net.Http.Headers;

namespace PlantAPI.Models.Helpers
{
    public class ApiHelper
    {
        public async Task<AstronomyPictureOfTheDay> GetAstronomyPictureOfTheDay(string uri)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(uri);

            return await response.Content.ReadFromJsonAsync<AstronomyPictureOfTheDay>();
        }
    }
}
