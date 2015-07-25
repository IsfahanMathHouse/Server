using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathHouse.Server.Models
{
	public class MessageViewModel
	{
		public int MessageId { get; set; }
		public string FromUser { get; set; }
		public int FromUserId { get; set; }
		public string AttachmentFileName { get; set; }
		public int? AttachmentSize { get; set; }
		public string Body { get; set; }
		public int? Stars { get; set; }
		public DateTime SendDate { get; set; }
		public string Subject { get; set; }
	}
}