using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SofiaMetroStations.Data
{
    public class StationManager
    {
        private const string BASE_URL = "http://drone.sumc.bg/api";
        public async Task<IEnumerable<Station>> GetAll()
        {
            // Get all metro stations
            string metroStationsUrl = BASE_URL + "/v1/metro/all";

            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(metroStationsUrl);
            client.Dispose();
            return JsonConvert.DeserializeObject<IEnumerable<Station>>(result);
        }

        public async Task<StationDetails> GetStationTimes(int stationId)
        {
            // Get all metro stations
            string stationTimesUrl = BASE_URL + $"/v1/metro/times/{stationId}";

            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(stationTimesUrl);
            client.Dispose();
            return JsonConvert.DeserializeObject<StationDetails>(result);
        }
    }
}

