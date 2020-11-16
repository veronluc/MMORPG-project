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
        public World World { get; set; }
        public User Creator { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }

        public Message()
        {

        }
    }
}
