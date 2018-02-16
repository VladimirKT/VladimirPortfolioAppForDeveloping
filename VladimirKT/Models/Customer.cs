using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VladimirKT.Models
{
	public class Customer
	{
		public int Id { get; set; }

		public string AspNetUsersId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public int Credit { get; set; }

		public int CardNumber { get; set; }

		public int NumburOfMovies { get; set; }

	}
}