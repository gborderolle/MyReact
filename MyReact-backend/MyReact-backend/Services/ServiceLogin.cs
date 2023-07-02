using MyReact_backend.Context;

namespace MyReact_backend.Services
{
	public class ServiceLogin
	{
		private readonly MyReactContext _myReactContext;

		public ServiceLogin(MyReactContext myReactContext)
		{
			_myReactContext = myReactContext;
		}

		internal void MakerLogin(int userID)
		{
		}
	}
}
