using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpHandler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
            var webClient = new HttpClient(httpHandler)
            {
                BaseAddress = new Uri("http://localhost:51332/api/")
            };

            var response = webClient.GetAsync("Test").Result;
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);

            Console.ReadLine();
        }
    }
}
