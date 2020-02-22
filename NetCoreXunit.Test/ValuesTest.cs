using Microsoft.AspNetCore.Mvc;
using NetCoreXunit.Controllers;
using NetCoreXunit.Interfaces;
using NetCoreXunit.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NetCoreXunit.Test
{
	public class ValuesTest
	{
		ILogic _logic;
		ValuesController _controller;
		public ValuesTest()
		{
			_logic = new Logic();
			_controller = new ValuesController(_logic);
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
			var result = _controller.Get(2);
			Assert.IsType<OkObjectResult>(result);
		}
	}
}
