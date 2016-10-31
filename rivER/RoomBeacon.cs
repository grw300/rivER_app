using System;
namespace rivER
{
    sealed public class RoomBeacon : Beacon
    {
        string value;
        public RoomBeacon()
        {
        }
        public override string Value
        {
            get
            {
                return value;
            }
            set
            {
                int i;
                if (int.TryParse(value, out i))
                {
                    this.value = string.Format("Room {0}", value);
                }
                else
                {
                    this.value = " -";
                }
            }
        }
    }
}
