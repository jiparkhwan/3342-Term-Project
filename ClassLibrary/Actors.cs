using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Actors
    {
        private String name;
        private String description;
        private String height;
        private String DOB;
        private String birthCity;
        private String birthState;
        private String birthCountry;
        private int actorID;
        private String image;

        public Actors()
        {

        }

        public Actors(string name, string description, string height, string dOB, string birthCity, string birthState, string birthCountry, int actorID, string image)
        {
            this.name = name;
            this.description = description;
            this.height = height;
            DOB = dOB;
            this.birthCity = birthCity;
            this.birthState = birthState;
            this.birthCountry = birthCountry;
            this.actorID = actorID;
            this.image = image;
        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Height { get => height; set => height = value; }
        public string DOB1 { get => DOB; set => DOB = value; }
        public string BirthCity { get => birthCity; set => birthCity = value; }
        public string BirthState { get => birthState; set => birthState = value; }
        public string BirthCountry { get => birthCountry; set => birthCountry = value; }
        public int ActorID { get => actorID; set => actorID = value; }
        public string Image { get => image; set => image = value; }
    }
}
