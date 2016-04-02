using System;
using System.IO;

namespace shit
{
    public class Program
    {
        static void Main(string[] args)
        {
            var location = Directory.GetCurrentDirectory();
            using (var server = new Server(location))
            {
                Clipboard.Set("http://localhost:" + server.Port);
                Console.WriteLine("Server is running on port: " + server.Port);
                while (true)
                {
                    // keep server alive
                }
            }
        }
    }
}
