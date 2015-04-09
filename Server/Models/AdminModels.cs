using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathHouse.Server.Models
{
	public class GroupModel
	{
		public int? GroupId { get; set; }
		public string Name { get; set; }
		public int GroupPublicityId { get; set; }
		public string Description { get; set; }
	}

	public class GroupPublicityModel
	{
		public int GroupPublicityId { get; set; }
		public string Name { get; set; }
	}
}