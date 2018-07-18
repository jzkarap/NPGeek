using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
	public class HomeController : Controller
	{
		private IParkDAL parkDAL;
		private IForecastDAL forecastDAL;

		private const string Temp_Celsius = "Celsius";

		public HomeController(IParkDAL parkDAL, IForecastDAL forecastDAL)
		{
			this.parkDAL = parkDAL;
			this.forecastDAL = forecastDAL;
		}

		public IActionResult Index()
		{
			var parks = parkDAL.GetAllParks();

			return View(parks);
		}

		[HttpGet]
		public IActionResult Detail(string id)
		{
			var park = parkDAL.GetPark(id);
			ViewBag.Forecast = forecastDAL.GetForecastForPark(id);

			return View(park);
		}

		[HttpPost]
		public IActionResult Detail()
		{
			int tempSwitch = 1;

			int tempChecker = Convert.ToInt32(HttpContext.Session.Get(Temp_Celsius));

			if (tempChecker != 1)
			{
				HttpContext.Session.Set(Temp_Celsius, BitConverter.GetBytes(tempSwitch));
			}
			else
			{
				HttpContext.Session.Clear();
			}

			return RedirectToAction("detail");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
