using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Models
{
	public class Survey
	{
		[Required]
		public string ParkCode { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string State { get; set; }
		[Required]
		public string ActivityLevel { get; set; }

		public static List<SelectListItem> ActivityLevelOptions = new List<SelectListItem>()
		{
			new SelectListItem() { Text = "Inactive" },
			new SelectListItem() { Text = "Sedentary" },
			new SelectListItem() { Text = "Active" },
			new SelectListItem() { Text = "Extremely Active" }
		};
	}
}
