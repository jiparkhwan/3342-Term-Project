using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data;

using Utilities;
using System.Data.SqlClient;
using ClassLibrary;
using System.Web;

using WebAPI.Models;
using Movies = WebAPI.Models.Movies;
using Actors = WebAPI.Models.Actors;
using TVShows = WebAPI.Models.TVShows;
using VideoGames = WebAPI.Models.VideoGames;
namespace WebAPI.Controllers
{
    [Route("WebAPI/review")]
    public class ReviewsController : Controller
    {
        [HttpDelete("DeleteReview/{id}")]  //Route: WebAPI/TermProject/DeleteReview/
        public Boolean DeleteReview(int id)
        {
            int retVal = StoredProcedures.DeleteReview(id);

            if (retVal > 0)
                return true;
            else
                return false;
        }
    }
}
