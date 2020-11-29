using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI12_DataObjects
{
    [Serializable()]
    public class ServerInfo
    {
        public string server { get; set; }
        public int port { get; set; }

        public ServerInfo(string server, int port) {
            this.server = server;
            this.port = port;
        }
    }
}