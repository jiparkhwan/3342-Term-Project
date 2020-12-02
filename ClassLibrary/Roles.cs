using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Roles
    {
        public String role { get; set; }
        public int movieID { get; set; }
        public String movieImage { get; set; }
        public String movieName { get; set; }
        public int movieYear { get; set; }
        public int actorID { get; set; }
        public int tvshowID { get; set; }
        public int videogameID { get; set; }

        public Roles()
        {

        }

        public Roles(string role, int actorID, int movieID, int tvshowID, int videogameID, string movieImage, string movieName, 
                     int movieYear)
        {
            this.role = role;
            this.actorID = actorID;
            this.movieID = movieID;
            this.tvshowID = tvshowID;
            this.videogameID = videogameID;
            this.movieImage = movieImage;
            this.movieName = movieName;
            this.movieYear = movieYear;
        }
    }
}
