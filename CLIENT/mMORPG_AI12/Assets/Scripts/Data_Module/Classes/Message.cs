using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class Message
    {
        public World world { get; set; }
        public User creator { get; set; }
        public string text { get; set; }
        public DateTime time { get; set; }

        public Message()
        {

        }

        public Message(World world, User creator, string text, DateTime time)
        {
            this.world = world;
            this.creator = creator;
            this.text = text;
            this.time = time;
        }
    }
}
