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

		[InverseProperty("Group")]
		public ICollection<UserGroup> UserGroups { get; set; }
	}
}
