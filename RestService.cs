using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadMoreSample
{
    public class RestService
    {
        public HttpClient _client;

        public RestService()
        {
            _client = new HttpClient(new HttpClientHandler());
        }

        public async Task<List<GameModel>> GetListGame()
        {
            List<GameModel> listGame = new List<GameModel>();

            var uri = new Uri("https://www.freetogame.com/api/games?platform=pc");

            HttpResponseMessage _responese = null;

            try
            {
                _responese = await _client.GetAsync(uri);

                if (_responese.IsSuccessStatusCode)
                {
                    var content = _responese.Content.ReadAsStringAsync().Result;
                    listGame = JsonConvert.DeserializeObject<List<GameModel>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return listGame.OrderBy(o => o.id).ToList();
        }
    }
}
