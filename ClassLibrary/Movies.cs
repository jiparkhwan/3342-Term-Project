using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Movies
    {
        public String name { get; set; }
        public int year { get; set; }
        public String description { get; set; }
        public int runtime { get; set; }
        public String ageRating { get; set; }
        public String Genre { get; set; }
        public float Budget { get; set; }
        public float income { get; set; }
        public int movieID { get; set; }
        public String image { get; set; }

        public Movies()
        {

        }

        public Movies(string name, int year, string description, int runtime, string ageRating, string genre, float budget, float income, int movieID, string image)
        {
            this.name = name;
            this.year = year;
            this.description = description;
            this.runtime = runtime;
            this.ageRating = ageRating;
            Genre = genre;
            Budget = budget;
            this.income = income;
            this.movieID = movieID;
            this.image = image;
        }

   
    }
}
