using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace rivER
{
    public sealed class RivERWebService : IRivERWebService
    {
        private static readonly string RIVER_WEBSERVICE_URL_FORMAT = "http://{0}/{1}/{2}";
        private static HttpClient Client { get; } = new HttpClient();

        public async Task<string> GetPersonnelReadRequest(string personnelID)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetRoomReadBedVacant(int roomNumber)
        {
            string[] urlStringParams = {
                Helpers.Settings.ServerAddress,
                "RivERWebService",
                string.Format("GetRoom?Room={0}&Command=ReadBedVacant",  roomNumber)};
            string urlString = string.Format(RIVER_WEBSERVICE_URL_FORMAT, urlStringParams);

            var token = await GetAsync(urlString);
            return (bool)token.SelectToken("BedVacant");
        }

        public async Task<Flags> GetRoomReadFlags(int roomNumber)
        {
            string[] urlStringParams = {
                Helpers.Settings.ServerAddress,
                "RivERWebService",
                string.Format("GetRoom?Room={0}&Command=ReadFlags",  roomNumber)};
            string urlString = string.Format(RIVER_WEBSERVICE_URL_FORMAT, urlStringParams);

            return await GetAsync<Flags>(urlString);
        }

        public async Task<Room> GetRoomReadRoom(int roomNumber)
        {
            string[] urlStringParams = {
                Helpers.Settings.ServerAddress,
                "RivERWebService",
                string.Format("GetRoom?Room={0}&Command=ReadRoom",  roomNumber)};
            string urlString = string.Format(RIVER_WEBSERVICE_URL_FORMAT, urlStringParams);

            return await GetAsync<Room>(urlString);
        }

        public async Task<bool> PostPersonnelAcknowledgeRequest(int roomNumber, string personnelID)
        {
            throw new NotImplementedException();
        }

		public async Task<bool> PostPersonnelIntoRoom(int roomNumber, string personnelID)
		{
			string[] urlStringParams = {
				Helpers.Settings.ServerAddress,
				"RivERWebService",
				"PostPersonnel"};

			string urlString = string.Format(RIVER_WEBSERVICE_URL_FORMAT, urlStringParams);
			var room = new { Room = roomNumber };
			var postString = string.Format("UID={0}&Data={1}&Command=IntoRoom",
                                           personnelID,
                                           JsonConvert.SerializeObject(room));

            return await PostAsync(urlString, postString);
        }

        public async Task<bool> PostPersonnelOutOfRoom(int roomNumber, string personnelID)
        {
            string[] urlStringParams = {
                Helpers.Settings.ServerAddress,
                "RivERWebService",
                "PostPersonnel"};

            string urlString = string.Format(RIVER_WEBSERVICE_URL_FORMAT, urlStringParams);
			var room = new { Room = roomNumber };
            var postString = string.Format("UID={0}&Data={1}&Command=OutOfRoom",
                                           personnelID,
                                           JsonConvert.SerializeObject(room));

            return await PostAsync(urlString, postString);
        }

        async Task<JToken> GetAsync(string urlString)
        {
            using (HttpResponseMessage response = await RivERWebService.Client.GetAsync(urlString))
            {
                if (response.IsSuccessStatusCode)
                {
                    var t = await response.Content.ReadAsStringAsync();
                    return JObject.Parse(t);
                }
                throw new HttpRequestException(string.Format("GET went wrong: {0}", urlString));
            }
        }

        async Task<T> GetAsync<T>(string urlString)
        {
            using (HttpResponseMessage response = await RivERWebService.Client.GetAsync(urlString))
            {
                if (response.IsSuccessStatusCode)
                {
                    var t = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(t);
                }
				throw new HttpRequestException(string.Format("GET went wrong: {0}", urlString));
            }
			//return (T)new object();
        }

        async Task<bool> PostAsync(string urlString, string postString)
        {
            var postContent = new StringContent(postString, Encoding.UTF8, "application/x-www-form-urlencoded");

			using (HttpResponseMessage response = RivERWebService.Client.PostAsync(urlString, postContent).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsStringAsync();
                    return true;
                }
				//throw new HttpRequestException(string.Format("POST went wrong: {0} {1}", urlString, postString));
            }
			return false;
        }
    }
}
