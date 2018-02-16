using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VladimirKT.Models
{
	public class MovieRepository
	{
		private ApplicationDbContext storeDB;

		public MovieRepository()
		{
			storeDB = new ApplicationDbContext();
		}

		public IEnumerable<Movie> GetAllMovies()
		{
			var movies = storeDB.Movies.ToList();
			return movies;
		}

		public Movie GetMovie(int id)
		{
			var movie = storeDB.Movies.SingleOrDefault(m => m.Id == id);
			return movie;
		}

		public void SetNewMovie(Movie movie)
		{
			storeDB.Movies.Add(movie);
		}

		public void Save()
		{
			storeDB.SaveChanges();
		}

		public void Delete(Movie movie)
		{
			storeDB.Movies.Remove(movie);
		}
	}
}