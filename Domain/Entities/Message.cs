using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathHouse.Domain.Entities
{
	public class Message
	{
		public int MessageId { get; set; }

		public int FromUserId { get; set; }
		[ForeignKey("FromUserId")]
		public User FromUser { get; set; }

		public int? GroupId { get; set; }
		public Group Group { get; set; }
		
		public int? ToUserId { get; set; }
		[ForeignKey("ToUserId")]
		public User ToUser { get; set; }
		
		public DateTime SendDate { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public string AttachmentFileName { get; set; }
		public int? AttachmentSize { get; set; }
		public int? MessageImportanceId { get; set; }
		public MessageImportance MessageImportance { get; set; }
	}
}