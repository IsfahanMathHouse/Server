using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MathHouse.Domain.Entities
{
	public class Group
	{
		public int GroupId { get; set; }
		public string Name { get; set; }
		
		public int OwnerUserId { get; set; }
		[ForeignKey("OwnerUserId")]
		public User Owner { get; set; }

		public int GroupPublicityId { get; set; }
		public GroupPublicity GroupPublicity { get; set; }

		public string Description { get; set; }

		[InverseProperty("Group")]
		public ICollection<UserGroup> UserGroups { get; set; }

		[InverseProperty("Group")]
		public ICollection<Message> Messages { get; set; }
	}
}
