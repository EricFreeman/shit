using System;
using System.IO;
using System.Runtime.InteropServices;

namespace shit
{
    public class Program
    {
        [DllImport("user32.dll")]
        internal static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll")]
        internal static extern bool CloseClipboard();

        [DllImport("user32.dll")]
        internal static extern bool SetClipboardData(uint uFormat, IntPtr data);

        static void Main(string[] args)
        {
            var location = Directory.GetCurrentDirectory();
            using (var server = new Server(location))
            {
                CopyToClipboard(server.Port);
                Console.WriteLine("Server is running on port: " + server.Port);
                while (true)
                {
                    // keep server alive
                }
            }
        }

        private static void CopyToClipboard(int port)
        {
            OpenClipboard(IntPtr.Zero);
            var yourString = "http://localhost:" + port;
            var ptr = Marshal.StringToHGlobalUni(yourString);
            SetClipboardData(13, ptr);
            CloseClipboard();
            Marshal.FreeHGlobal(ptr);
        }
    }
}
