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

		[HttpPost]
		[Route("SendMessage")]
		public SendMessageResponse SendMessage(SendMessageRequest request)
		{
			//TODO: Verify is the user is allowed to send messages to this group
			try
			{
				using (var context = ImhDbContext.Get())
				{
					var message = context.Messages.Create();
					message.FromUserId = 3;
					message.Body = request.Message;
					message.GroupId = request.GroupId;
					message.SendDate = DateTime.Now;
					message.MessageImportanceId = 1;
					context.Messages.Add(message);
					context.SaveChanges();
					return new SendMessageResponse { Succeeded = true };
				}
			}
			catch (Exception ex)
			{
				//TODO: Log the error, do something about it!
				return new SendMessageResponse { Succeeded = false };
			}
		}

		[HttpPost]
		[Route("GetNewMessages")]
		public IEnumerable<MessageViewModel> GetNewMessages(GetNewMessagesRequest request)
		{
			//TODO:Check if the user has access to this group
			using (var context = ImhDbContext.Get())
			{
				var messsages = context.Messages.Where(x => x.GroupId == request.GroupId && x.MessageId > request.LastMessageId)
					.OrderByDescending(x => x.SendDate)
					.Select(m => new MessageViewModel
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
					}).ToList();
				return messsages;
			}
		}
	}
}