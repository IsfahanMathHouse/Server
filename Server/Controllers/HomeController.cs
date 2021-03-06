﻿using MathHouse.Domain;
using MathHouse.Server.Infrastructure;
using MathHouse.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MathHouse.Server.Controllers
{
	public class HomeController : SpecializedController
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult GroupsList()
		{
			return View();
		}
	}
}