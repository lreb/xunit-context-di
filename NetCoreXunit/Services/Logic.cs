using NetCoreXunit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreXunit.Services
{
	public class Logic : ILogic
	{
		private readonly List<string> Values = new List<string>();
		public Logic()
		{
			Values.Add("a");
			Values.Add("b");
			Values.Add("b");
		}
		public string GetValue(int index)
		{
			return Values[index];
		}

		public List<string> GetValues()
		{
			return Values;
		}
	}
}
