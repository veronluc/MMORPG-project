﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI12_DataObjects
{
    public class Message
    {
        public World world { get; set; }
        public User creator { get; set; }
        public string Text { get; set; }
        public DateTime time { get; set; }

        public Message()
        {

        }
    }
}
