using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NetCoreXunit.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreXunit
{
	//public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
	//{
	//	public ApplicationContext CreateDbContext(string[] args)
	//	{
	//		IConfigurationRoot configuration = new ConfigurationBuilder()
	//			.SetBasePath(Directory.GetCurrentDirectory())
	//			.AddJsonFile("appsettings.json")
	//			.Build();

	//		var builder = new DbContextOptionsBuilder<ApplicationContext>();

	//		var connectionString = configuration.GetConnectionString("DefaultConnection");

	//		builder.UseNpgsql(configuration["PostgreSql:ConnectionString"]);

	//		return new ApplicationContext(builder.Options);
	//	}
	//}
}
