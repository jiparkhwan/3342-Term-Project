using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Movies
    {
        private String name;
        private int year;
        private String description;
        private int runtime;
        private String ageRating;
        private String Genre;
        private float Budget;
        private float income;
        private int movieID;
        private String image;

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

        public string Name { get => name; set => name = value; }
        public int Year { get => year; set => year = value; }
        public string Description { get => description; set => description = value; }
        public int Runtime { get => runtime; set => runtime = value; }
        public string AgeRating { get => ageRating; set => ageRating = value; }
        public string Genre1 { get => Genre; set => Genre = value; }
        public float Budget1 { get => Budget; set => Budget = value; }
        public float Income { get => income; set => income = value; }
        public int MovieID { get => movieID; set => movieID = value; }
        public string Image { get => image; set => image = value; }
    }
}
