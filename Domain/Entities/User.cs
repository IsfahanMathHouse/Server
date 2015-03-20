using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MathHouse.Domain.Entities
{
	public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
	{
		[Index(IsUnique = true)]
		[Required]
		[MaxLength(256)]
		public string DisplayName { get; set; }

		[InverseProperty("Owner")]
		public ICollection<Group> OwnerGroups { get; set; }
		[InverseProperty("User")]
		public ICollection<UserGroup> UserGroups { get; set; }

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}

	}
}