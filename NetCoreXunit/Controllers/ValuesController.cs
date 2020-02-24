using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreXunit.Data;
using NetCoreXunit.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NetCoreXunit.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		// private readonly ILogic _logic;
		private readonly NetCoreXunitContext _db;
		public ValuesController(NetCoreXunitContext db)
		{
			// _logic = logic;
			_db = db;
		}
		// GET api/values
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_db.Value.ToList());
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			Value value = _db.Value.Include(x => x.ValueProperties).Where(x => x.ValueId == id).FirstOrDefault(); 
			return Ok(_db.Value.Find(id));
		}

		// POST api/values
		[HttpPost]
		public IActionResult Post([FromBody] Value value)
		{
			_db.Add<Value>(value);
			_db.SaveChanges();
			return CreatedAtAction(nameof(Get), new { id = value.ValueId }, value);
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] Value value)
		{
			if (!ModelState.IsValid )
				return BadRequest("Not a valid model");

			Value originalValue = _db.Value.Where(x => x.ValueId == id).FirstOrDefault();

			if (originalValue != null)
			{
				originalValue.Content = value.Content;
				originalValue.Status = value.Status;

				_db.Update<Value>(originalValue);
				_db.SaveChanges();
			}
			else
			{
				return NotFound();
			}
			return CreatedAtAction(nameof(Get), new { id = originalValue.ValueId }, originalValue);
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			Value tempValue = _db.Value.Where(x => x.ValueId == id).FirstOrDefault();
			if (tempValue != null)
			{
				_db.Remove<Value>(tempValue);
				_db.SaveChanges();
			}
			else
			{
				return NotFound();
			}
			return NoContent();
		}
	}
}
