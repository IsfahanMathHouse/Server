using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathHouse.Domain.Entities
{
	public class GroupPublicity
	{
		public int GroupPublicityId { get; set; }
		public string Name { get; set; }
		public bool DoNotListToAnonymous { get; set; }
		public bool IsVisibleToAnonymous { get; set; }
		public bool UsersCanBecomeMember { get; set; }
		public bool MembershipRequiresApproval { get; set; }
		public bool NonApprovedMembersCanViewMessages { get; set; }
	}
}
