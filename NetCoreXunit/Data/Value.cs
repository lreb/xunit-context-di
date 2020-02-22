using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreXunit.Data
{
	public class Value
	{
		[Key]
		public long ValueId { get; set; }
		public string Content { get; set; }
		public Status Status { get; set; }

		public ICollection<ValueProperty> ValueProperties { get; set; }
	}
}
