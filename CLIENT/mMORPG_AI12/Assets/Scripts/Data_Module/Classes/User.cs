using System;
using System.Collections.Generic;

namespace AI12_DataObjects
{
    [Serializable()]
    public class User
    {
        public string login { get; set; }
		public string id { get; set; }
		public string password { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public DateTime birthDate { get; set; }
		public string imageRef { get; set; }
		public List<Player> players { get; set; }
		public List<World> worlds { get; set; }

        public User()
        {

        }

        public User(string login, string id, string password, string firstName, string lastName, DateTime birthDate, string imageRef, List<Player> players, List<World> worlds)
        {
            this.login = login;
            this.id = id;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.imageRef = imageRef;
            this.players = players;
            this.worlds = worlds;
        }
    }
}
