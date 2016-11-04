using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Flags
{
	[JsonObject(MemberSerialization.OptOut)]
	public class Flag
	{
		public IList<bool> State;
		public IList<int> Color;
	}
}