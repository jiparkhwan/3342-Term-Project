using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Serializable]
    public class MemberFavorites
    {
        private String favoriteMovie;
        private String favoriteVideoGame;
        private String favoriteTVShow;
        private String favoriteActor;

        public string FavoriteMovie { get => favoriteMovie; set => favoriteMovie = value; }
        public string FavoriteVideoGame { get => favoriteVideoGame; set => favoriteVideoGame = value; }
        public string FavoriteTVShow { get => favoriteTVShow; set => favoriteTVShow = value; }
        public string FavoriteActor { get => favoriteActor; set => favoriteActor = value; }
    }
}
