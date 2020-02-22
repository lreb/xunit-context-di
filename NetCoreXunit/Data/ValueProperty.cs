using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreXunit.Data
{
	public class ValueProperty
	{
		[Key]
		public long ValuePropertyId { get; set; }
		public string Group { get; set; }
		public string Name { get; set; }
		public string Content { get; set; }

		[ForeignKey("ValueForeignKey")]
		public long ValueId { get; set; }
		public Value Value { get; set; }
	}
}
