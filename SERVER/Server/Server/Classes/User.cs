using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI12_DataObjects
{
	[Serializable()]
	public class User
	{
		public string Login { get; set; }
		public string Id { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
		public string ImageRef { get; set; }
		public List<Player> Players { get; set; }

		public User()
		{

		}
	}
}
