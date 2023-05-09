using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WODWarriors.Services
{
    public class ExerciseApiService
    {
        private const string RapidApiKey = "006f0b0f3fmsh8953e8e6fd3b6bbp19deeejsnbbb8a2928219";
        private const string RapidApiHost = "exercises-by-api-ninjas.p.rapidapi.com";

        private static readonly HttpClient client = new HttpClient();

        private BodyPartList _body = new();

        internal async Task<BodyPartList> GetWorkoutDetailsAsync(string muscle)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://exercises-by-api-ninjas.p.rapidapi.com/v1/exercises?muscle={muscle}"),
                Headers =
                    {
                        { "X-RapidAPI-Key", RapidApiKey },
                        { "X-RapidAPI-Host", RapidApiHost },
                    },
            };

            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(jsonString))
            {
                throw new ArgumentException("The JSON string is null or empty", nameof(jsonString));
            }
            _body = JsonConvert.DeserializeObject<BodyPartList>(jsonString);
            return _body;
        }
    }
}
