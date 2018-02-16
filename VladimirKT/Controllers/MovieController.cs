using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VladimirKT.Models;
using VladimirKT.ViewModels;

namespace VladimirKT.Controllers
{
    public class MovieController : Controller
    {

		MovieRepository movieRepository = new MovieRepository();
		public static string IMAGES_FOLDER = "/Content/Images/movies/";

		// GET: MovieHome
		public ActionResult MovieIndex()
        {
            return View();
        }

		public ActionResult ListOfMovies()
		{
			MovieViewModel viewModel = new MovieViewModel();
			viewModel.Movies = movieRepository.GetAllMovies();
			return View(viewModel);
		}

		public ActionResult GetJsonDataForMovies() 
		{
			var obj = movieRepository.GetAllMovies();
		
			return this.Json(obj, JsonRequestBehavior.AllowGet);
		}

		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult ManageListOfMovies()
		{
			return View();
		}

		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult AddNewMovie()
		{
			return View();
		}

		[HttpPost]
		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult CreateMovie(Movie movie)
		{
			Movie newMovie = new Movie();
			if (ModelState.IsValid)
			{
				if (movie.ImagePath != null)
				{ 
			         newMovie.ImagePath = "/Content/Images/movies/" + ExtractFileName(movie.ImagePath);
				}
				newMovie.Name = movie.Name;
				
			     newMovie.Year = movie.Year;
				
				 newMovie.Price = movie.Price;
				
				 newMovie.Description = movie.Description;
				
				 newMovie.Actors = movie.Actors;
				
				 newMovie.Duration = movie.Duration;
				
				 newMovie.Director = movie.Director;
				
				 newMovie.Genre = movie.Genre;
				
				movieRepository.SetNewMovie(newMovie);
				movieRepository.Save();
			}

			return RedirectToAction("ManageListOfMovies", "Movie");
		}

		public ActionResult MovieDetails(int Id)
		{
			MovieViewModel viewModel = new MovieViewModel();
			viewModel.Movie = movieRepository.GetMovie(Id);
			return View(viewModel);
		}

		[HttpPost]
		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult DeleteMovie(int Id)
		{
			Movie deleteMovie = movieRepository.GetMovie(Id);

			if (deleteMovie.ImagePath != null)
			{
				DeleteImage(deleteMovie.ImagePath);
			}

			movieRepository.Delete(deleteMovie);
			movieRepository.Save();

			return RedirectToAction("ManageListOfMovies", "Movie");
		}

		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult EditMovie(int Id)
		{
			Movie editMovie = movieRepository.GetMovie(Id);
			MovieViewModel viewModel = new MovieViewModel();
			viewModel.Movie = editMovie;

			return View(viewModel);
		}

		[HttpPost]
		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult EditMovie(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				MovieViewModel viewModel = new MovieViewModel();
				viewModel.Movie = movie;			

				return View("EditMovie", viewModel);
			}

			Movie editMovie = movieRepository.GetMovie(movie.Id);

			if (movie.ImagePath != null)
			{
		      DeleteImage(editMovie.ImagePath);
			  editMovie.ImagePath = "/Content/Images/movies/" + ExtractFileName(movie.ImagePath);
			}

			editMovie.Name = movie.Name;

			editMovie.Year = movie.Year;

			editMovie.Price = movie.Price;

			editMovie.Description = movie.Description;

			editMovie.Actors = movie.Actors;

			editMovie.Duration = movie.Duration;

			editMovie.Director = movie.Director;

			editMovie.Genre = movie.Genre;

			movieRepository.Save();

			return RedirectToAction("ManageListOfMovies", "Movie");
		}

		public ActionResult AboutApp()
		{
			return View();
		}


		[HttpPost]	
		public void UploadImage()
		{
			
			if (HttpContext.Request.Files.Count > 0)
			{

				for (int i = 0; i < HttpContext.Request.Files.Count; i++)
				{
					HttpPostedFileBase file = HttpContext.Request.Files[i];
					
						file.SaveAs(HttpContext.Server.MapPath(IMAGES_FOLDER) + ExtractFileName(file.FileName));														
				}
			}
		}

		public void DeleteImage(string imagePath)
		{
			var fullPath = Request.MapPath(imagePath);
			System.IO.File.Delete(fullPath);
		}

		private string ExtractFileName(string fileName)
		{
			if (fileName.Contains('\\'))
			{
				string[] fileNamePathParts = fileName.Split('\\');
				return fileNamePathParts[fileNamePathParts.Length - 1];
			}
			else
			{
				return fileName;
			}
		}
	}
}