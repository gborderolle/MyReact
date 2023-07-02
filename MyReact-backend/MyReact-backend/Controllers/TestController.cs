using Microsoft.AspNetCore.Mvc;
using MyReact_backend.Models;
using MyReact_backend.Services;

namespace MyReact_backend.Controllers
{
	[Route("api/Test")]
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly ServiceEmployee _serviceEmployee;
		public TestController(ServiceEmployee serviceEmployee)
		{
			_serviceEmployee = serviceEmployee;
		}

		[HttpPost]
		[Route("Registration")]
		public string Registration(Employee employee)
		{
			_serviceEmployee.CreateEmployee(employee);
			return "Employee added";
		}

	}
}
