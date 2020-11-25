using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class Message
    {
        public string worldId { get; set; }
        public string creatorId { get; set; }
        public string text { get; set; }
        public DateTime time { get; set; }

        public Message()
        {

        }

        public Message(string world, string creator, string text, DateTime time)
        {
            this.worldId = world;
            this.creatorId = creator;
            this.text = text;
            this.time = time;
        }
    }
}
