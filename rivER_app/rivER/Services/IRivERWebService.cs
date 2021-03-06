﻿using System;
using System.Threading.Tasks;

namespace rivER
{
	public interface IRivERWebService
	{
		Task<Room> GetRoomReadRoom(int roomNumber);
		Task<Personnel> GetPersonnelReadRequest(string personnelID);
		Task<bool> GetRoomReadBedVacant(int roomNumber);
		Task<Flags> GetRoomReadFlags(int roomNumber);
		Task<bool> PostPersonnelIntoRoom(int roomNumber, string personnelID);
		Task<bool> PostPersonnelOutOfRoom(int roomNumber, string personnelID);
		Task<bool> PostPersonnelAcknowledgeRequest(string requestID, string personnelID);
	}
}
