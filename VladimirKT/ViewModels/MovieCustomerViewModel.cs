using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VladimirKT.Models;

namespace VladimirKT.ViewModels
{
	public class MovieCustomerViewModel
	{
		public Customer Customer { get; set; }
		public Movie Movie { get; set; }
		public List<string> MovieNames { get; set; } 
	}
}