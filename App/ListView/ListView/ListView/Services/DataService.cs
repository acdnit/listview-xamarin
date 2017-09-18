using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using ListView.Models;
using Newtonsoft.Json;

namespace ListView.Services {
    public class DataService : IDataService {
        public async Task<ObservableCollection<Person>> GetListPersionAsync() {
            try {
                var json = await GetContentFromUrl("http://192.168.1.100:8888/api/person/list");
                return JsonConvert.DeserializeObject<ObservableCollection<Person>>(json);
            }
            catch (Exception) {
                return new ObservableCollection<Person>();
            }
        }

        public async Task<string> GetContentFromUrl(string url) {
            try {
                var client = new HttpClient(new HttpClientHandler());
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var respone = await client.SendAsync(request);
                if (respone.IsSuccessStatusCode) return await respone.Content.ReadAsStringAsync();
                return string.Empty;
            }
            catch (Exception) {
                return string.Empty;
            }
        }
    }
}