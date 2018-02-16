using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Security.Principal;

namespace VladimirKT.Models
{
	public class UserRepository
	{
		public ApplicationDbContext storeDB; 

		public UserRepository()
		{
			storeDB = new ApplicationDbContext();
		}


	}
}