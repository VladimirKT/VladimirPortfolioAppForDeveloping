using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VladimirKT.Models
{
	public class MovieCustomer
	{
		public int Id { get; set; }

		public string CustomerId { get; set; }

		public int MovieId { get; set; }

		public Customer Customers { get; set; }

		public Movie Movies { get; set; }

	}
}