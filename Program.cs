using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SimpleLineNotifyApp
{
    class Program
    {
        // private static readonly HttpClient client = new HttpClient();
        private static async Task ProcessRepositories(string token, string Params) {
            using(HttpClient client = new HttpClient(new LoggingHandler(new HttpClientHandler()))) {
                // clear request headers
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri("https://notify-api.line.me/");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var form = new FormUrlEncodedContent(new[] {
                    new KeyValuePair<string, string>("message", Params)
                });

                // StringContent content = new StringContent(Params);
                // content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                HttpResponseMessage responseMessage = await client.PostAsync("api/notify", form);

                Console.WriteLine(await responseMessage.Content.ReadAsStringAsync());
            }
        }

        static void Main(string[] args)
        {   
            string token = "5mux5jOtE9TLf6rfXY3YIyEq1UiycGK8T45buHXjUpP";

            string Params = "I'm here!";

            // Call The Method Using Await
            ProcessRepositories(token, Params).GetAwaiter().GetResult();
            // End This Program
            return;
        }
    }
}
