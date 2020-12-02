using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Movies
    {
        public String movieName { get; set; }
        public int movieYear { get; set; }
        public String movieDescription { get; set; }
        public int movieRuntime { get; set; }
        public String movieAgeRating { get; set; }
        public String movieGenre { get; set; }
        public float movieBudget { get; set; }
        public float movieIncome { get; set; }
        public int movieID { get; set; }
        public String movieImage { get; set; }

        public int memberID { get; set; }
        public Movies()
        {

        }

        public Movies(int memberID, string name, int year, string description, int runtime, string ageRating, string genre, float budget, float income, int movieID, string image)
        {
            this.memberID = memberID;
            this.movieName = name;
            this.movieYear = year;
            this.movieDescription = description;
            this.movieRuntime = runtime;
            this.movieAgeRating = ageRating;
            this.movieGenre = genre;
            this.movieBudget = budget;
            this.movieIncome = income;
            this.movieID = movieID;
            this.movieImage = image;
        }


    }
}
