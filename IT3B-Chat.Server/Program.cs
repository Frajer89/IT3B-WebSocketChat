using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT3B_Chat.Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Server server = new Server("ws://localhost:8080/");
            await server.Start();
        }
    }
}
