using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TennisStats.API.Models;

namespace TennisStats.API
{
    public class TennisStatsAPIClient : IDisposable
    {
        private readonly HttpClient _client;
        private readonly Uri _baseUri = new Uri("https://data.latelier.co/training/tennis_stats/headtohead.json");

        public TennisStatsAPIClient()
        {
            _client = new HttpClient() { BaseAddress = _baseUri };
        }
        public void Dispose()
        {
            _client.Dispose();
        }
        public async Task<IEnumerable<Player>> GetPlayers(string search, int page)
        {
            string url = "";

            if (page == 0)
            {
                url = this._baseUri.AbsoluteUri;
            }
            else
            {

                url = AddPlayerParamsToUrl(search, page);
            }

            HttpResponseMessage response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string resp = await response.Content.ReadAsStringAsync();
            var x = (JsonConvert.DeserializeObject<IDictionary<string, object>>(resp)["players"]);

            try
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<Player>>(x.ToString());
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        private string AddPlayerParamsToUrl(string search, int page = 1)
        {
            Dictionary<string, string> queryParameters = new Dictionary<string, string>();
            if (page != 0)
                queryParameters.Add(nameof(page), page.ToString());
            if (!string.IsNullOrEmpty(search))
            {
                queryParameters.Add(nameof(search), search);
                return QueryHelpers.AddQueryString(_baseUri.OriginalString, queryParameters);
            }

            return QueryHelpers.AddQueryString(_baseUri.OriginalString, queryParameters);
        }
    }
}
