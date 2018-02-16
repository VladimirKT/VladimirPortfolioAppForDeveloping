using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VladimirKT.Models;
using VladimirKT.ViewModels;

namespace VladimirKT.Controllers
{
    public class CustomerController : Controller
    {
		CustomerRepository customerRepository = new CustomerRepository();
		MovieRepository movieRepository = new MovieRepository();
	
        // GET: Customer
        public ActionResult Index()
        {
			
			string userId = User.Identity.GetUserId();
			MovieCustomerViewModel viewModel = new MovieCustomerViewModel();
			viewModel.Customer = customerRepository.GetCustomer(userId);
			viewModel.MovieNames = customerRepository.GetAllMoviesForCustomer(userId).ToList();

			return View(viewModel);
        }

		public ActionResult GetCustomerJsonData() 
		{

			string userId = User.Identity.GetUserId();
			Customer customers = new Customer();
			customers = customerRepository.GetCustomer(userId);

			return this.Json(customers, JsonRequestBehavior.AllowGet);
		}

		public ActionResult BuyMovie(MovieViewModel model)
		{
			string userId = User.Identity.GetUserId();
			MovieCustomer movieCustomer = new MovieCustomer();
			movieCustomer.CustomerId = userId;
			movieCustomer.MovieId = model.Movie.Id;
			Customer customers = customerRepository.GetCustomer(userId);
			customers.Credit -= 25;
			customers.NumburOfMovies += 1;
			customerRepository.SetMovieCustomer(movieCustomer);
			customerRepository.Save();
			return RedirectToAction("Index", "Customer");
		}
	}
}