using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace rivER
{
	[JsonObject(MemberSerialization.OptOut)]
	public class Flag
	{
		public IList<bool> State;
		public IList<int> Color;
	}
}