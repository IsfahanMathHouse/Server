using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathHouse.Domain.Helpers
{
	public static class CommonHelpers
	{
		public static void ComputeMigrations<TDbContext>(Func<TDbContext> contextGenerator)
			where TDbContext : DbContext
		{
			using (var context = contextGenerator())
			{
				var migratorConfig = new DbMigrationsConfiguration<TDbContext>();
				migratorConfig.AutomaticMigrationsEnabled = true;
				migratorConfig.AutomaticMigrationDataLossAllowed = true;
				migratorConfig.TargetDatabase = new System.Data.Entity.Infrastructure.DbConnectionInfo(context.Database.Connection.ConnectionString, "System.Data.SqlClient");
				var dbMigrator = new DbMigrator(migratorConfig);
				dbMigrator.Update();
			}
		}
	}
}
