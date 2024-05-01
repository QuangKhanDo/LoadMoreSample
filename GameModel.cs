using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadMoreSample
{
    public class GameModel
    {
        /*"id": 517,
        "title": "Lost Ark",
        "thumbnail": "https://www.freetogame.com/g/517/thumbnail.jpg",
        "short_description": "Smilegate’s free-to-play multiplayer ARPG is a massive adventure filled with lands waiting to be explored, people waiting to be met, and an ancient evil waiting to be destroyed.",
        "game_url": "https://www.freetogame.com/open/lost-ark",
        "genre": "ARPG",
        "platform": "PC (Windows)",
        "publisher": "Amazon Games",
        "developer": "Smilegate RPG",
        "release_date": "2022-02-11",
        "freetogame_profile_url": "https://www.freetogame.com/lost-ark"
        */
        public string id { get; set; }
        public string title { get; set; }
        public string thumbnail { get; set; }
        public string short_description { get; set; }
        public string game_url { get; set; }
        public string genre { get; set; }
        public string platform { get; set; }
        public string publisher { get; set; }
        public string developer { get; set; }
        public string release_date { get; set; }
    }
}
