using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
	public class Forecast
	{
		public string ParkCode { get; set; }
		public int DayOfForecast { get; set; }
		public int LowTemp { get; set; }
		public int HighTemp { get; set; }
		public string Description { get; set; }

		public string GetImageName()
		{
			string output = "";

			if (Description == "partly cloudy")
			{
				output = "partlyCloudy.png";
			}
			else if (Description == "thunderstorms")
			{
				output = "thunderstorms.png";
			}
			else if (Description == "sunny")
			{
				output = "sunny.png";
			}
			else if (Description == "cloudy")
			{
				output = "cloudy.png";
			}
			else if (Description == "rain")
			{
				output = "rain.png";
			}
			else
			{
				output = "snow.png";
			}

			return output;
		}

		public string GetAdviceForWeather()
		{
			string advice = "";

			if (Description == "sunny")
			{
				advice = "Be sure to pack your sunscreen!  SPF 30 at a minimum.";
			}
			else if (Description == "thunderstorms")
			{
				advice = "Bad day for park.  Seek shelter and avoid hiking on exposed ridges today.";
			}
			else if (Description == "snow")
			{
				advice = "Bring your snowshoes today and watch out for snowdrifts.";
			}
			else if (Description == "rain")
			{
				advice = "Pack your raingear and wear waterproof shoes when visiting today.";
			}
			else
			{
				advice = "Enjoy your day.";
			}

			return advice;
		}

		public string GetAdviceForTemp()
		{
			string advice = "";

			if (HighTemp > 75)
			{
				advice += "Be sure to bring an extra gallon of water today. ";
			}
			else if (LowTemp < 20)
			{
				advice += "Take extreme care when in the park today due to cold weather conditions. Extremeties could fall off. ";
			}

			if ((HighTemp - LowTemp) > 20)
			{
				advice += "Wear breathable layers when out at the park today. ";
			}

			return advice;
		}
	}
}
