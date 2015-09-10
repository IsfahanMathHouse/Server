using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathHouse.Server.Models
{
	public class GetNewMessagesRequest
	{
		public int GroupId { get; set; }
		public int LastMessageId { get; set; }
	}
}