using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            var postString = string.Format("Room={0}&Data={1}&Command=IntoRoom",
                                           roomNumber,
                                           JsonConvert.SerializeObject(personnelID));

            return await PostAsync(urlString, postString);
        }

        public async Task<bool> PostPersonnelOutOfRoom(int roomNumber, string personnelID)
        {
            string[] urlStringParams = {
                Helpers.Settings.ServerAddress,
                "RivERWebService",
                "PostPersonnel"};

            string urlString = string.Format(RIVER_WEBSERVICE_URL_FORMAT, urlStringParams);
            var postString = string.Format("Room={0}&Data={1}&Command=OutOfRoom",
                                           roomNumber,
                                           JsonConvert.SerializeObject(personnelID));

            return await PostAsync(urlString, postString);
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
                throw new HttpRequestException("GET went wrong");
            }
        }

        async Task<bool> PostAsync(string urlString, string postString)
        {
            var postContent = new StringContent(postString, Encoding.UTF8, "application/x-www-form-urlencoded");

            using (HttpResponseMessage response = await RivERWebService.Client.PostAsync(urlString, postContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsStringAsync();
                    return true;
                }
                throw new HttpRequestException("POST went wrong");
            }
        }
    }
}
