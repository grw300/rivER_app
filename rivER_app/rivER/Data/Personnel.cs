using System;
using System.Collections.Generic;

namespace rivER
{
	public class Personnel
	{
		public string Name { get; set; }
		public int Role { get; set; }
		public string PUID { get; set; }
		public List<Request> Requests { get; set; }

		public Personnel()
		{
			Requests = new List<Request>();
		}
	}
}
