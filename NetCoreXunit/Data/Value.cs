using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreXunit.Data
{
	public class Value
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long ValueId { get; set; }
		public string Content { get; set; }
		public Status Status { get; set; }

		public ICollection<ValueProperty> ValueProperties { get; set; }
	}
}
