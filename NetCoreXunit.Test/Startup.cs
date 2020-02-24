using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;
using Xunit.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using NetCoreXunit.Data;
using NetCoreXunit.Controllers;

namespace NetCoreXunit.Test
{
	public class Startup : DependencyInjectionTestFramework
	{
		public Startup(IMessageSink messageSink) : base(messageSink)
		{
			// register service collection
			var services = new ServiceCollection();
			// reads configuration
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile(
					 path: "appsettings.json",
					 optional: false,
					 reloadOnChange: true)
			   .Build();

			// Inject context
			var connectionString = configuration["PostgreSql:ConnectionString"];
			services.AddDbContext<NetCoreXunitContext>(o => o.UseNpgsql(connectionString));

			// controllers
			services.AddTransient<ValuesController, ValuesController>();

			// Build service
			ServiceProvider = services.BuildServiceProvider();
		}
		public ServiceProvider ServiceProvider { get; private set; }
		protected override void ConfigureServices(IServiceCollection services)
		{
			throw new NotImplementedException();
		}
	}
}
