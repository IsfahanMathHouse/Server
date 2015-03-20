using MathHouse.Domain;
using MathHouse.Domain.Entities;
using MathHouse.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MathHouse.Server.Controllers
{
	public class MessagingController : ApiController
	{
		public IEnumerable<GroupsListViewModel> GetGroupsList()
		{
			using (var context = ImhDbContext.Get())
			{
				IQueryable<Group> query = context.Groups;
				if (!User.Identity.IsAuthenticated)
				{
					query = query.Where(x => !x.GroupPublicity.DoNotListToAnonymous);
				}
				var groups = context.Groups.Select(x => new GroupsListViewModel
					{
						GroupId = x.GroupId,
						Publicity = x.GroupPublicity.Name,
						Name = x.Name,
						Owner = x.Owner.DisplayName,
						OwnerUserId = x.OwnerUserId,
						UsersCount = x.UserGroups.Count,
						MessageCount = x.Messages.Count
					});
				return groups;
			}
		}
	}
}