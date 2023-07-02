using MyReact_backend.Context;
using MyReact_backend.Models;

namespace MyReact_backend.Services
{
	public class ServiceEmployee
	{
		private readonly MyReactContext _myReactContext;

		public ServiceEmployee(MyReactContext MyReactContext)
		{
			_myReactContext = MyReactContext;
		}

		#region CRUD methods

		internal void CreateEmployee(Employee Employee)
		{
			if (Employee != null)
			{
				_myReactContext.Employee.Add(Employee);
				_myReactContext.SaveChanges();
			}
		}

		internal void DeleteEmployee(int id)
		{
			if (id > 0)
			{
				Employee Employee = GetEmployee(id);
				if (Employee != null)
				{
					_myReactContext.Employee.Remove(Employee);
					_myReactContext.SaveChanges();
				}
			}
		}

		internal void UpdateEmployee(Employee Employee)
		{
			if (Employee != null)
			{
				_myReactContext.Employee.Update(Employee);
				_myReactContext.SaveChanges();
			}
		}

		#endregion

		#region Public methods

		internal Employee GetEmployee(int id)
		{
			Employee Employee = new();
			if (id > 0)
			{
				Employee = _myReactContext.Employee.FirstOrDefault(e => e.EmployeeId == id);
			}
			return Employee;
		}

		#endregion

	}
}

