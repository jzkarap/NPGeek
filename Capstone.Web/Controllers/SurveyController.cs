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

		[HttpGet]
		public IActionResult TakeSurvey()
		{
			var parks = parkDAL.GetAllParks();

			var options = parks.Select<Park, SelectListItem>(park => new SelectListItem() { Text = park.ParkName, Value = park.ParkCode });
			ViewBag.Parks = options;

			Survey survey = new Survey();

			return View(survey);
		}

		[HttpPost]
		public IActionResult TakeSurvey(Survey survey)
		{
			if (ModelState.IsValid)
			{
				if (surveyDAL.SubmitSurvey(survey) == true)
				{
					TempData["Submitted"] = true;
					return RedirectToAction("Index");
				}
				else
				{
					return RedirectToAction("SurveyError");
				}
			}

			var parks = parkDAL.GetAllParks();

			var options = parks.Select<Park, SelectListItem>(park => new SelectListItem() { Text = park.ParkName, Value = park.ParkCode });
			ViewBag.Parks = options;

			return View(survey);
			
		}

		public IActionResult SurveyError()
		{
			return View();
		}
    }
}