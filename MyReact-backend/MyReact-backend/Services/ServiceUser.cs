using MyReact_backend.Context;
using MyReact_backend.Models;

namespace MyReact_backend.Services
{
	public class ServiceUser
	{
		private readonly MyReactContext _myReactContext;

		public ServiceUser(MyReactContext myReactContext)
		{
			_myReactContext = myReactContext;
		}

		#region CRUD methods

		internal void CreateUser(User user)
		{
			if (user != null)
			{
				_myReactContext.User.Add(user);
				_myReactContext.SaveChanges();
			}
		}

		internal void DeleteUser(int id)
		{
			if (id > 0)
			{
				User user = GetUser(id);
				if (user != null)
				{
					_myReactContext.User.Remove(user);
					_myReactContext.SaveChanges();
				}
			}
		}

		internal void UpdateUser(User user)
		{
			if (user != null)
			{
				_myReactContext.User.Update(user);
				_myReactContext.SaveChanges();
			}
		}

		#endregion

		#region Public methods

		internal User GetUser(int id)
		{
			User user = new();
			if (id > 0)
			{
				user = _myReactContext.User
					.FirstOrDefault(e => e.UserID == id);
			}
			return user;
		}

		internal User Login(VMLogin modelLogin)
		{
			if (modelLogin == null)
			{
				return null;
			}
			var (username, password) = modelLogin;
			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{
				return null;
			}
			return _myReactContext.User
				.SingleOrDefault(e => e.Username == username && e.Password == password);
		}

		#endregion

	}
}
