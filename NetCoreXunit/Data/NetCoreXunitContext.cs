using Microsoft.EntityFrameworkCore;
using NetCoreXunit.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreXunit.Data
{
	public class NetCoreXunitContext : DbContext
	{
		public NetCoreXunitContext(DbContextOptions<NetCoreXunitContext> options)
				: base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			foreach (var entity in modelBuilder.Model.GetEntityTypes())
			{

				entity.Relational().TableName = entity.Relational().TableName.ToSnakeCase();
				
				foreach (var property in entity.GetProperties()) 
					property.Relational().ColumnName = property.Name.ToSnakeCase();

				foreach (var key in entity.GetKeys())
					key.Relational().Name = key.Relational().Name.ToSnakeCase();

				foreach (var key in entity.GetForeignKeys())
					key.Relational().Name = key.Relational().Name.ToSnakeCase();

				foreach (var index in entity.GetIndexes())
					index.Relational().Name = index.Relational().Name.ToSnakeCase();

				// Drop the 'asp_net_' prefix from the Identity tables
				if (entity.Relational().TableName.StartsWith("asp_net_"))
				{
					entity.Relational().TableName = entity.Relational().TableName.Replace("asp_net_", string.Empty);
				}
			}


		}

		public DbSet<Value> Value { get; set; }
		public DbSet<ValueProperty> ValueProperty { get; set; }
	}
}
