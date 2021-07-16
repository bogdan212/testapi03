using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Text.RegularExpressions;

using System.IO;



namespace testapi1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program coma = new Program();
            
            Console.WriteLine(coma.GetDataFromServer(10, 10));

            Console.ReadLine();
        }

        public int GetDataFromServer(int a, int b)
        {
            var client = new RestClient("http://demo.macroscop.com:8080/configex?login=root&password=");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            Console.WriteLine(response.Content.Contains("<Channel"));

            //var periodFrom = new DateTime(response.Content);


            // string path = response.Content;
            //string pattern = @"\w*<Channel\w*";
            // string target = "9999999999";
            // Regex regex = new Regex(pattern);
            //string result = regex.Replace(response.Content, target);

            //Console.WriteLine(result);
            int count = 1;
            Regex regex = new Regex(@"\w*<ChannelInfo\w*");
            MatchCollection matches = regex.Matches(response.Content);
            if ( matches.Count <= 6)
            {
                
                
                foreach (Match match in matches)
                    Console.WriteLine(match.Value);
                return 1;

            }
            else
            {
                return a + b;
            }
            


                
        }
    }
}
