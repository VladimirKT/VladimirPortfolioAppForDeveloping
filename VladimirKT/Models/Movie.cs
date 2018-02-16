using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VladimirKT.Models
{
	public class Movie
	{
		public int Id { get; set; }
		
		[StringLength(255)]
		public string ImagePath { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Required]
		[StringLength(255)]
		public string Year { get; set; }

		[Required]
		[StringLength(255)]
		public string Price { get; set; }

		[Required]
		[StringLength(755)]
		public string Description { get; set; }

		[Required]
		[StringLength(255)]
		public string Director { get; set; }

		[Required]
		[StringLength(555)]
		public string Actors { get; set; }

		[Required]
		[StringLength(255)]
		public string Duration { get; set; }

		[Required]
		[StringLength(255)]
		public string Genre { get; set; } 
	}
}