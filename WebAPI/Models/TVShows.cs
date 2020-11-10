using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TVShows
    {
        private String Name;
        private String years;
        private String ageRating;
        private int runtime;
        private String genre;
        private String description;
        private String image;
        private int ID;

        public TVShows()
        {

        }

        public TVShows(int ID, string name, string years, string ageRating, int runtime, string genre, string description, string image)
        {
            this.ID = ID;
            Name = name;
            this.years = years;
            this.ageRating = ageRating;
            this.runtime = runtime;
            this.genre = genre;
            this.description = description;
            this.image = image;
        }

        public string Name1 { get => Name; set => Name = value; }
        public string Years { get => years; set => years = value; }
        public string AgeRating { get => ageRating; set => ageRating = value; }
        public int Runtime { get => runtime; set => runtime = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Description { get => description; set => description = value; }
        public string Image { get => image; set => image = value; }
        public int ID1 { get => ID; set => ID = value; }
    }
}
