using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class VideoGames
    {
        private String gameName;
        private int gameYear;
        private String gameGenre;
        private String gameDescription;
        private String gameCreator;
        private String gameAgeRating;
        private string gameImage;
        private int gameID;
        private int memberID;
        public VideoGames()
        {

        }

        public VideoGames(int memberID, string name, int year, string genre, string description, string creator, string ageRating, string image, int videoGameID)
        {
            this.MemberID = memberID;
            this.gameName = name;
            this.gameYear = year;
            this.gameGenre = genre;
            this.gameDescription = description;
            this.gameCreator = creator;
            this.gameAgeRating = ageRating;
            this.gameImage = image;
            this.gameID = videoGameID;
        }

        public string GameName { get => gameName; set => gameName = value; }
        public int GameYear { get => gameYear; set => gameYear = value; }
        public string GameGenre { get => gameGenre; set => gameGenre = value; }
        public string GameDescription { get => gameDescription; set => gameDescription = value; }
        public string GameCreator { get => gameCreator; set => gameCreator = value; }
        public string GameAgeRating { get => gameAgeRating; set => gameAgeRating = value; }
        public string GameImage { get => gameImage; set => gameImage = value; }
        public int GameID { get => gameID; set => gameID = value; }
        public int MemberID { get => memberID; set => memberID = value; }
    }
}
