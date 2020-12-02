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
        public String titleImage { get; set; }
        public String movieName { get; set; }
        public int movieYear { get; set; }
        public int actorID { get; set; }
        public String actorImage { get; set; }
        public String actorName { get; set; }
        public int tvshowID { get; set; }
        public String tvShowImage { get; set; }
        public String tvShowName { get; set; }
        public String tvShowYears { get; set; }
        public int videoGameID { get; set; }
        public String videoGameImage { get; set; }
        public String videoGameName { get; set; }
        public int videoGameYear { get; set; }

        public Roles()
        {

        }

        public Roles(string role, int actorID, int movieID, int tvshowID, int videoGameID, string titleImage, string movieName, 
                     int movieYear, string actorImage, string actorName, string tvShowImage, string tvShowName, string tvShowYears,
                     string videoGameImage, string videoGameName, int videoGameYear)
        {
            this.role = role;
            this.actorID = actorID;
            this.movieID = movieID;
            this.tvshowID = tvshowID;
            this.videoGameID = videoGameID;
            this.titleImage = titleImage;
            this.movieName = movieName;
            this.movieYear = movieYear;
            this.actorImage = actorImage;
            this.actorName = actorName;
            this.tvShowImage = tvShowImage;
            this.tvShowName = tvShowName;
            this.tvShowYears = tvShowYears;
            this.videoGameImage = videoGameImage;
            this.videoGameName = videoGameName;
            this.videoGameYear = videoGameYear;
        }
    }
}