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

		[JsonIgnore]
		public IEnumerable<FlagColor> FlagColor
		{
			get
			{
				foreach (var state in this.State)
				{
					foreach (var color in this.Color)
					{
						if (state)
						{
							switch (color)
							{
								case 0:
									yield return new FlagColor { Color = "#ED1C24"};
									break;
								case 1:
									yield return new FlagColor { Color = "#00A2E8" };
									break;
								case 2:
									yield return new FlagColor { Color = "#22B14C" };
									break;
								case 3:
									yield return new FlagColor { Color = "#FFF200" };
									break;
							}
						}
						else
						{
							switch (color)
							{
								case 0:
									yield return new FlagColor { Color = "#6C0000" };
									break;
								case 1:
									yield return new FlagColor { Color = "#114451" };
									break;
								case 2:
									yield return new FlagColor { Color = "#4D620B" };
									break;
								case 3:
									yield return new FlagColor { Color = "#9B9400" };
									break;
							}
						}
					}
				}
			}
		}
	}
}