using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathHouse.Server.Models
{
	public class SendMessageRequest
	{
		public int GroupId { get; set; }
		public string Message { get; set; }
	}
}