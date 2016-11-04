using System;

namespace rivER
{
	public class FlagColor
	{
        public FlagColor(bool state, int color)
        {
            this.Color = Tuple.Create(state, color);
        }
		public Tuple<bool, int> Color { get; private set; }
	}
}
