using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class VideoGames
    {
        private String name;
        private int year;
        private String genre;
        private String description;
        private String creator;
        private String ageRating;
        private string Image;
        private int videoGameID;
        public VideoGames()
        {

        }

        public string Name { get => name; set => name = value; }
        public int Year { get => year; set => year = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Description { get => description; set => description = value; }
        public string Creator { get => creator; set => creator = value; }
        public string AgeRating { get => ageRating; set => ageRating = value; }
        public string Image1 { get => Image; set => Image = value; }
        public int VideoGameID { get => videoGameID; set => videoGameID = value; }
    }
}
