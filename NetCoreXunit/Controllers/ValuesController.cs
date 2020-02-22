using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreXunit.Interfaces;

namespace NetCoreXunit.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly ILogic _logic;
		public ValuesController(ILogic logic)
		{
			_logic = logic;
		}
		// GET api/values
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_logic.GetValues());
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok(_logic.GetValue(id));
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
