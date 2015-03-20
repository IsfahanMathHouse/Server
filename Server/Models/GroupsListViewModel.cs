using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathHouse.Server.Models
{
	public class GroupsListViewModel
	{
		public int GroupId { get; set; }
		public string Publicity { get; set; }
		public string Name { get; set; }
		public string Owner { get; set; }
		public int OwnerUserId { get; set; }
		public int UsersCount { get; set; }
		public int MessageCount { get; set; }
	}
}