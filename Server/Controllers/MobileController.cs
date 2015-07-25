using MathHouse.Domain;
using MathHouse.Server.Infrastructure;
using MathHouse.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MathHouse.Server.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[RoutePrefix("api/mobile")]
	public class MobileController : ApiController
	{
		[HttpPost]
		public IEnumerable<GroupsListViewModel> GetGroups()
		{
			using (var context = ImhDbContext.Get())
			{
				var groups = context.Groups.Select(g => new GroupsListViewModel
				{
					GroupId = g.GroupId,
					MessageCount = g.Messages.Count,
					Name = g.Name,
					Owner = g.Owner.DisplayName,
					OwnerUserId = g.OwnerUserId,
					Publicity = g.GroupPublicity.Name,
					UsersCount = g.UserGroups.Count
				}).ToList();
				return groups;
			}
		}

		[HttpPost]
		[Route("DownloadGroupInfo")]
		public GroupViewModel DownloadGroupInfo(GetGroupInfoRequest request)
		{
      using (var context = ImhDbContext.Get())
			{
				var group = context.Groups.Where(x => x.GroupId == request.GroupId).Select(g => new GroupViewModel
					{
						GroupId = g.GroupId,
						MessageCount = g.Messages.Count,
						Name = g.Name,
						Owner = g.Owner.DisplayName,
						OwnerUserId = g.OwnerUserId,
						Publicity = g.GroupPublicity.Name,
						UsersCount = g.UserGroups.Count,
						Description = g.Description,
						Messages = g.Messages.OrderByDescending(x => x.SendDate).Take(30).Select(m => new MessageViewModel
						{
							MessageId = m.MessageId,
							FromUser = m.FromUser.DisplayName,
							FromUserId = m.FromUserId,
							AttachmentFileName = m.AttachmentFileName,
							AttachmentSize = m.AttachmentSize,
							Body = m.Body,
							Stars = m.MessageImportance.Stars,
							SendDate = m.SendDate,
							Subject = m.Subject
						})
					}).Single();
				return group;
			}
		}
	}
}