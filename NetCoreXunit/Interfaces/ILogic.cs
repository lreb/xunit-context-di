using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreXunit.Interfaces
{
	public interface ILogic
	{
		List<string> GetValues();
		string GetValue(int index);
	}
}
