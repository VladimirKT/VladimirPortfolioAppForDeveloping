using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VladimirKT.Models
{
	public class CustomerRepository
	{
		private ApplicationDbContext storeDB;

		public CustomerRepository()
		{
			storeDB = new ApplicationDbContext();
		}

		public Customer GetCustomer(string id)
		{
			var customer = storeDB.Customers.SingleOrDefault(c => c.AspNetUsersId == id);
			return customer;
		}

		public void SetMovieCustomer(MovieCustomer movieCustomer)
		{
			storeDB.MoviesCustomers.Add(movieCustomer);
		}

		public IEnumerable<string> GetAllMoviesForCustomer(string customerId)
		{
			var moviesId = (from mc in storeDB.MoviesCustomers

							where mc.CustomerId == customerId 

							select mc.Movies.Name).ToList();

			return moviesId;
		}

		public void Save()
		{
			storeDB.SaveChanges();
		}
	}
}