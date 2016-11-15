using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rivER
{
    public class RoomViewModel : BaseViewModel
    {
        private Room room;
        public Room Room
        {
            get
            {
                return room;
            }
            set
            {
                if (room != value)
                {
                    room = value;
                    OnPropertyChanged("Room");

                    //TODO: This is silly, there must be a better way.
                    this.Flags = room.Flags;
                    this.BedVacant = room.BedVacant;
                    this.InRoomPersonnel = room.InRoomPersonnel;
                    this.RoomRequests = room.RoomRequests;
                    this.BeaconId = room.BeaconId;
                    this.BedURL = room.BedURL;
                    this.RoomNumber = room.RoomNumber;
                }
            }
        }

        public Flags Flags
        {
            get
            {
                return room.Flags;
            }
            set
            {
                if (room.Flags != value)
                {
                    room.Flags = value;
                    OnPropertyChanged("Flags");
                }
            }
        }
        public bool? BedVacant
        {
            get
            {
                return room.BedVacant;
            }
            set
            {
                if (room.BedVacant != value)
                {
                    room.BedVacant = value;
                    OnPropertyChanged("BedVacant");
                }
            }
        }
        public List<string> InRoomPersonnel
        {
            get
            {
                return room.InRoomPersonnel;
            }
            set
            {
                if (room.InRoomPersonnel != value)
                {
                    room.InRoomPersonnel = value;
                    OnPropertyChanged("InRoomPersonnel");
                }
            }
        }
        public List<string> RoomRequests
        {
            get
            {
                return room.RoomRequests;
            }
            set
            {
                if (room.RoomRequests != value)
                {
                    room.RoomRequests = value;
                    OnPropertyChanged("RoomRequests");
                }
            }
        }
        public string BeaconId
        {
            get
            {
                return room.BeaconId;
            }
            set
            {
                if (room.BeaconId != value)
                {
                    room.BeaconId = value;
                    OnPropertyChanged("BeaconId");
                }
            }
        }
        public string BedURL
        {
            get
            {
                return room.BedURL;
            }
            set
            {
                if (room.BedURL != value)
                {
                    room.BedURL = value;
                    OnPropertyChanged("BedURL");
                }
            }
        }
        public int? RoomNumber
        {
            get
            {
                return room.RoomNumber;
            }
            set
            {
                if (room.RoomNumber != value)
                {
                    room.RoomNumber = value;
                    OnPropertyChanged("RoomNumber");
                }
            }
        }

        public RoomViewModel(INavigation navigation) : base(navigation)
        {
            room = new Room();
        }
    }
}
