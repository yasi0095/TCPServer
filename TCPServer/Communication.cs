using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using FootballPLayer;
using Newtonsoft.Json;

namespace TCPServer
{
    public class Communication
    {
        public static List<FootballPlayer> FP = new List<FootballPlayer>()
        {
            new FootballPlayer(7, "Christiano Ronaldo", 750, 7),
            new FootballPlayer(10, "Lionel Messi", 750, 31),
            new FootballPlayer(8, "Andre Silva", 750, 11)
        };

        public void start()
        {
            TcpClient socket = new TcpClient("127.0.0.1", 2121);

            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                // read line from keyboard
                Console.Write("Write a line : ");
                String line = Console.ReadLine();

                sw.WriteLine(line);
                sw.Flush();
                sw.AutoFlush = true;

                String str = sr.ReadLine();
                Console.WriteLine("Server svar: " + str);

                switch (str)
                {
                    case "HentAlle":
                        Console.WriteLine(JsonConvert.SerializeObject(FP));
                        sw.WriteLine(JsonConvert.SerializeObject(FP));
                        break;
                    case "HentID":
                        int id = Int32.Parse(sr.ReadLine());
                        string aser = FP.Find(fp => fp.Id == id).ToString();
                        Console.WriteLine(JsonConvert.SerializeObject(aser));
                        sw.WriteLine(JsonConvert.SerializeObject(aser));
                        break;
                    case "Gem":
                        string jstring = sr.ReadLine();
                        FootballPlayer fp = JsonConvert.DeserializeObject<FootballPlayer>(jstring);
                        FP.Add(fp);
                        break;
                }

                Console.WriteLine("");
            }






        }
    }
}
