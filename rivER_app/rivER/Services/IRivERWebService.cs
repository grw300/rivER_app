using System;
using System.Threading.Tasks;

namespace rivER
{
	public interface IRivERWebService
	{
		Task<Room> GetRoomReadRoom(int roomNumber);
		Task<string> GetPersonnelReadRequest(string personnelID);
        Task<bool> GetRoomReadBedVacant(int roomNumber);
        Task<bool> GetRoomReadFlags(int roomNumber);
        Task<bool> PostPersonnelIntoRoom(int roomNumber, string personnelID);
		Task<bool> PostPersonnelOutOfRoom(int roomNumber, string personnelID);
		Task<bool> PostPersonnelAcknowledgeRequest(int roomNumber, string personnelID);
	}
}
