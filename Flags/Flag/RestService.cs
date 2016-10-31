using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Flag
{
    class RestService
    {


        HttpClient client;

       public RestService()
        {
            var authData = string.Format("{0}:{1}", "", "");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }


        public async Task DoSomethingAsync()
        {
            Task<int> delayTask = DelayAsync();
            int result = await delayTask;

            // The previous two statements may be combined into
            // the following statement.
            //int result = await DelayAsync();

            Debug.WriteLine("Result: " + result);
        }

        public async Task<int> DelayAsync()
        {
            await Task.Delay(100);
            return 5;
        }



        public async Task<string> AddAsync()
        {
            // RestUrl = http://developer.xamarin.com:8081/api/todoitems{0}
            var uri = new Uri("http://127.0.0.1:8080/WebService1/Add?b=2&a=9");
            //Debug.WriteLine(uri.ToString);
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    //Items = JsonConvert.DeserializeObject<List<TodoItem>>(content);
                    return content;
                }
                return "";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
                return "";
            }
        }
    }
}