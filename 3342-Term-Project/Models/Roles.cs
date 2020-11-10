using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3342_Term_Project.Models
{
    public class Roles
    {

        private String role;
        private int actorID;
        private int movieID;
        private int tvshowID;
        private int videogameID;
        public Roles()
        {

        }

        public Roles(string role, int actorID, int movieID, int tvshowID, int videogameID)
        {
            this.role = role;
            this.actorID = actorID;
            this.movieID = movieID;
            this.tvshowID = tvshowID;
            this.videogameID = videogameID;
        }

        public string Role { get => role; set => role = value; }
        public int ActorID { get => actorID; set => actorID = value; }
        public int MovieID { get => movieID; set => movieID = value; }
        public int TvshowID { get => tvshowID; set => tvshowID = value; }
        public int VideogameID { get => videogameID; set => videogameID = value; }
    }
}
