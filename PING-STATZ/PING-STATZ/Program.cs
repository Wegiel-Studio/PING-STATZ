using System;
using System.Drawing;
using Console = Colorful.Console;
using Colorful;
using System.Threading;
using System.Net.NetworkInformation;
using System.IO;

namespace PING_STATZ
{    
    class Program
    {       
        static void Main(string[] args)
        {
            string version = "1.0.0";

            Console.WriteAscii("PING-STATZ", Color.FromArgb(12, 50, 230));
            Console.Write("Ver: " + version, Color.LightBlue);
            Console.WriteLine();

            //var filepath = File.Create(@"dataping.json");

            testing();
        }

        static void testing()
        {
            string ip = "8.8.8.8";

            int h, m, s;

            while (true)
            {
                Thread.Sleep(1000);
                try
                {
                    Ping myPing = new Ping();
                    PingReply reply = myPing.Send(ip, 80);
                    if (reply != null)
                    {
                        h = Int32.Parse(DateTime.Now.ToString("HH"));
                        m = Int32.Parse(DateTime.Now.ToString("mm"));
                        s = Int32.Parse(DateTime.Now.ToString("ss"));
                        Console.WriteLine();
                        Console.WriteLine("PING: " + reply.Status + " \n TIME: " + reply.RoundtripTime.ToString() + " \n IP : " + reply.Address + " " + DateTime.Now.ToString("HH:mm:ss"));
                        
                        string[] tosave = { reply.Status.ToString(), ";", reply.RoundtripTime.ToString(), ";", reply.Address.ToString(), ";", DateTime.Now.ToString("HH:mm:ss") };

                        string savehelp = "";

                        savehelp = string.Join("", tosave);

                        string path = @"dataping.json"; //fake json 
                        //File.WriteAllText(path, savehelp);
                        File.WriteAllLines(path, tosave);
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("ERROR: " + e);
                }
            }
        }
    }
}
