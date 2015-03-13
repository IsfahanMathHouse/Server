using MathHouse.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathHouse.Domain
{
	public class ImhDbContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>
	{
		public static ImhDbContext Get()
		{
			return new ImhDbContext();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
		}

		public ImhDbContext()
			: base("ImhConnectionString")
		{

		}

		public DbSet<Group> Groups { get; set; }
		public DbSet<GroupAccessLevel> GroupAccessLevels { get; set; }
		public DbSet<GroupPublicity> GroupPublicities { get; set; }
	}
}