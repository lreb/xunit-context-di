using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCoreXunit.Data;
using NetCoreXunit.Interfaces;
using NetCoreXunit.Services;
using Npgsql;

namespace NetCoreXunit
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<ILogic, Logic>();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			var connectionString = Configuration["PostgreSql:ConnectionString"];
			var dbPassword = Configuration["PostgreSql:DbPassword"];

			var builder = new NpgsqlConnectionStringBuilder(connectionString)
			{
				Password = dbPassword
			};
			services.AddEntityFrameworkNpgsql()
				.AddDbContext<NetCoreXunitContext>(options => 
				options.UseNpgsql("Host=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=postgres;"));

			//services.AddDbContext<ApplicationContext>(options =>
			//	options.UseNpgsql(Configuration.GetConnectionString("PostgreSql:ConnectionString")));
			// services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}
