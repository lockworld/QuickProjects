using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CallAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string qstring = string.Empty;
            bool quit = false;
            while (!quit)
            {
                //string data = "RuleName=DoesPartExist&PartNumber=10017000";
                //WriteLog(data);
                Console.WriteLine("API URL: ");
                string apiURL = Console.ReadLine();
                Console.WriteLine("Data String: ");
                string data = Console.ReadLine();
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiURL);
                    request.Method = WebRequestMethods.Http.Post;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;

                    StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
                    requestWriter.Write(data);
                    requestWriter.Close();

                    WebResponse webResponse = request.GetResponse();
                    Stream webStream = webResponse.GetResponseStream();
                    StreamReader responseReader = new StreamReader(webStream);
                    var responseString = Regex.Unescape(responseReader.ReadToEnd()).Trim('"');
                    Console.WriteLine("Response:");
                    Console.WriteLine(responseString);
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }


                Console.Write("Quit application? (Y/N): ");
                qstring = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                quit = qstring.Equals("y", StringComparison.CurrentCultureIgnoreCase);
            }
        }
    }
}
