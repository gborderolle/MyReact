using Microsoft.AspNetCore.Mvc;
using MyReact_backend.Models;
using MyReact_backend.Services;

namespace MyReact_backend.Controllers
{
	[Route("api/User")]
	[ApiController]

	public class UserController : Controller
	{
		private readonly ServiceUser _serviceUser;
		public UserController(ServiceUser serviceUser)
		{
			_serviceUser = serviceUser;
		}

		[HttpPost]
		[Route("AddUser")]
		public string AddUser(User user)
		{
			_serviceUser.CreateUser(user);
			return "Usuario agregado";
		}

	}
}