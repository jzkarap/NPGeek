using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
		private ISurveyDAL surveyDAL;

		public SurveyController(ISurveyDAL surveyDAL)
		{
			this.surveyDAL = surveyDAL;
		}

        public IActionResult Index()
        {
			var results = surveyDAL.GetResults();

            return View(results);
        }

		public IActionResult TakeSurvey()
		{
			return View();
		}
    }
}