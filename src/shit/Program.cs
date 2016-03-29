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
                Console.WriteLine("Server is running on this port: " + server.Port);
                while (true)
                {
                    // keep server alive
                }
            }
        }
    }
}
