using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VladimirKT.Models;

namespace VladimirKT.ViewModels
{
	public class MovieViewModel
	{
		public IEnumerable<Movie> Movies { get; set; }
		public Movie Movie { get; set; }

		[Required]
		[Display(Name = "Yours Credit card number")]
		[Range(1000000, 9999999, ErrorMessage = "Please enter 7 digits number between 1000000 and 9999999")]
		public int CardNumber { get; set; }
	}
}