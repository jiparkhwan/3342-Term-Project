using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Actors
    {
        private String actorName;
        private String actorDescription;
        private String actorHeight;
        private String actorDOB;
        private String actorBirthCity;
        private String actorBirthState;
        private String actorBirthCountry;
        private int actorID;
        private String actorImage;

        public Actors()
        {

        }

        public Actors(string name, string description, string height, string dOB, string birthCity, string birthState, string birthCountry, int actorID, string image)
        {
            this.actorName = name;
            this.actorDescription = description;
            this.actorHeight = height;
            this.actorDOB = dOB;
            this.actorBirthCity = birthCity;
            this.actorBirthState = birthState;
            this.actorBirthCountry = birthCountry;
            this.actorID = actorID;
            this.actorImage = image;
        }

        public string ActorName { get => actorName; set => actorName = value; }
        public string ActorDescription { get => actorDescription; set => actorDescription = value; }
        public string ActorHeight { get => actorHeight; set => actorHeight = value; }
        public string ActorDOB { get => actorDOB; set => actorDOB = value; }
        public string ActorBirthCity { get => actorBirthCity; set => actorBirthCity = value; }
        public string ActorBirthState { get => actorBirthState; set => actorBirthState = value; }
        public string ActorBirthCountry { get => actorBirthCountry; set => actorBirthCountry = value; }
        public int ActorID { get => actorID; set => actorID = value; }
        public string ActorImage { get => actorImage; set => actorImage = value; }
    }
}
