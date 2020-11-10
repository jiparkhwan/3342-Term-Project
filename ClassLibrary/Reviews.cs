using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class Reviews
    {
        private float avgRating;
        private String description;
        public Reviews()
        {

        }

        public float AvgRating { get => avgRating; set => avgRating = value; }
        public string Description { get => description; set => description = value; }
    }
}
