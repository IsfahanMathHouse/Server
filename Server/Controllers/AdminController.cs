using MathHouse.Domain;
using MathHouse.Server.Infrastructure;
using MathHouse.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MathHouse.Server.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : SpecializedController
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public JsonResult GetGroupPublicities()
		{
			using (var context = ImhDbContext.Get())
			{
				var groupPublicities = context.GroupPublicities.Select(x => new GroupPublicityModel
				{
					GroupPublicityId = x.GroupPublicityId,
					Name = x.Name
				}).ToList();
				return Json(groupPublicities);
			}
		}

		public JsonResult SaveGroup(GroupModel model)
		{
			using (var context = ImhDbContext.Get())
			{
				var group = model.GroupId.HasValue
					? context.Groups.Single(x => x.GroupId == model.GroupId)
					: context.Groups.Create();
				group.Name = model.Name;
				group.GroupPublicityId = model.GroupPublicityId;
				group.Description = model.Description;
				if (!model.GroupId.HasValue)
				{
					group.OwnerUserId = User.Identity.GetUserId<int>();
					context.Groups.Add(group);
				}
				try
				{
					context.SaveChanges();
					return Json(true);
				}
				catch
				{
					return Json(false);
				}
			}
		}

		public ActionResult Groups()
		{
			return View();
		}
	}
}