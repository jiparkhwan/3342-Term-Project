using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Reviews
    {
        
        private float avgRating;
        private String description;
        private int reviewID;
        private int movieID;
        private int videogameID;
        private int tvshowID;
        public Reviews()
        {

        }

        public Reviews(float avgRating, string description, int reviewID, int movieID, int videogameID, int tvshowID)
        {
            this.avgRating = avgRating;
            this.description = description;
            this.reviewID = reviewID;
            this.movieID = movieID;
            this.videogameID = videogameID;
            this.tvshowID = tvshowID;
        }

        public float AvgRating { get => avgRating; set => avgRating = value; }
        public string Description { get => description; set => description = value; }
        public int ReviewID { get => reviewID; set => reviewID = value; }
        public int MovieID { get => movieID; set => movieID = value; }
        public int VideogameID { get => videogameID; set => videogameID = value; }
        public int TvshowID { get => tvshowID; set => tvshowID = value; }
    }
}
