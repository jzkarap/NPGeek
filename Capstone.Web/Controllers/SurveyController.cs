using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
		private ISurveyDAL surveyDAL;
		private IParkDAL parkDAL;

		public SurveyController(ISurveyDAL surveyDAL, IParkDAL parkDAL)
		{
			this.surveyDAL = surveyDAL;
			this.parkDAL = parkDAL;
		}

        public IActionResult Index()
        {
			var results = surveyDAL.GetResults();

            return View(results);
        }

		public IActionResult TakeSurvey()
		{
			var parks = parkDAL.GetAllParks();

			var options = parks.Select<Park, SelectListItem>(park => new SelectListItem() { Text = park.ParkName, Value = park.ParkCode });
			ViewBag.Parks = options;

			return View();
		}
    }
}