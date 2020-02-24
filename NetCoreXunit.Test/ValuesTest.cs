using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NetCoreXunit.Controllers;
using NetCoreXunit.Data;
using NetCoreXunit.Interfaces;
using NetCoreXunit.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NetCoreXunit.Test
{
	public class ValuesTest : IClassFixture<Startup>
	{
		//b readonly ILogic _logic;
		// ValuesController _controller;

		/// <summary>
		/// Service collection
		/// </summary>
		private readonly ServiceProvider _serviceProvider;
		/// <summary>
		/// Controller reference
		/// </summary>
		private readonly ValuesController _controller;

		public ValuesTest(Startup setup)
		{
			//_logic = new Logic();
			//_controller = new ValuesController(_logic);
			_serviceProvider = setup.ServiceProvider;
			_controller = _serviceProvider.GetService<ValuesController>();
		}
		[Fact]
		public void GetValues()
		{
			var result = _controller.Get();
			Assert.IsType<OkObjectResult>(result);
		}
		[Fact]
		public void GetValue()
		{
			var result = _controller.Get(1);
			Assert.IsType<OkObjectResult>(result);
		}
		[Fact]
		public void PostValue()
		{
			ICollection<ValueProperty> valueProperties = new List<ValueProperty>();
			var valueProperty = new ValueProperty()
			{
				Group = "xGroup",
				Name = "test",
				Content = "value"
			};
			valueProperties.Add(valueProperty);
			var value = new Value()
			{
				Content = "xUnit",
				Status = Status.Progress,
				ValueProperties = valueProperties
			};
			var result = _controller.Post(value);
			Assert.IsType<CreatedAtActionResult>(result);
		}
	}
}
