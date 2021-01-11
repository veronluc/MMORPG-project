using System;

namespace Server
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ServerMain server = new ServerMain();
            server.Start();
        }
    }
}
