using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI12_DataObjects
{
    [Serializable()]
    public class Message
    {
        public String worldId { get; set; }
        public String creatorId { get; set; }
        public string text { get; set; }
        public DateTime time { get; set; }

        public Message()
        {

        }
    }
}
