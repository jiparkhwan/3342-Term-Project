using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{


    class Actors
    {
        private String FName;
        private String LName;
        private String description;
        private String height;
        private String DOB;
        private int birthCity;
        private String birthState;
        private String birthCountry;
        private int actorID;
        public Actors()
        {

        }

        public string FName1 { get => FName; set => FName = value; }
        public string LName1 { get => LName; set => LName = value; }
        public string Description { get => description; set => description = value; }
        public string Height { get => height; set => height = value; }
        public string DOB1 { get => DOB; set => DOB = value; }
        public int BirthCity { get => birthCity; set => birthCity = value; }
        public string BirthState { get => birthState; set => birthState = value; }
        public string BirthCountry { get => birthCountry; set => birthCountry = value; }
        public int ActorID { get => actorID; set => actorID = value; }
    }
}
