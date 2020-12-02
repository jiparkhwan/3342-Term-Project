using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class TVShows
    {
        private String showName;
        private String showYears;
        private String showAgeRating;
        private int showRuntime;
        private String showGenre;
        private String showDescription;
        private String showImage;
        private int showID;
        private int memberID;
        public TVShows()
        {

        }

        public TVShows(int memberID, int ID, string name, string years, string ageRating, int runtime, string genre, string description, string image)
        {
            this.MemberID = memberID;
            this.showID = ID;
            this.showName = name;
            this.showYears = years;
            this.showAgeRating = ageRating;
            this.showRuntime = runtime;
            this.showGenre = genre;
            this.showDescription = description;
            this.showImage = image;
        }

        public string ShowName { get => showName; set => showName = value; }
        public string ShowYears { get => showYears; set => showYears = value; }
        public string ShowAgeRating { get => showAgeRating; set => showAgeRating = value; }
        public int ShowRuntime { get => showRuntime; set => showRuntime = value; }
        public string ShowGenre { get => showGenre; set => showGenre = value; }
        public string ShowDescription { get => showDescription; set => showDescription = value; }
        public string ShowImage { get => showImage; set => showImage = value; }
        public int ShowID { get => showID; set => showID = value; }
        public int MemberID { get => memberID; set => memberID = value; }
    }
}
