using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI12_DataObjects
{
    public class User
    {
		public string login { get; set; }
		public string password { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public DateTime birthDate { get; set; }
		public string imageRef { get; set; }
		public List<Player> players { get; set; }

		public User ()
        {

        }
	}
}
