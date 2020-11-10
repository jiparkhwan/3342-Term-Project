using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class Members
    {

        private String email;
        private String password;
        private String Username;
        private String Fname;
        private String Lname;
        private String DOB;
        private int memberID;
        public Members()
        {

        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Username1 { get => Username; set => Username = value; }
        public string Fname1 { get => Fname; set => Fname = value; }
        public string Lname1 { get => Lname; set => Lname = value; }
        public string DOB1 { get => DOB; set => DOB = value; }
        public int MemberID { get => memberID; set => memberID = value; }
    }
}
