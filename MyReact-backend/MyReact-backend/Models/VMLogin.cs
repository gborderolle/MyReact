using System.ComponentModel.DataAnnotations;

namespace MyReact_backend.Models
{
	public class VMLogin
	{
		[Required(ErrorMessage = "Por favor, ingrese este dato")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Por favor, ingrese este dato")]
		public string Password { get; set; }

		public bool KeepLoggedIn { get; set; }

		/// <summary>
		/// Invento de ChatGPT: "Desestructuración"
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		public void Deconstruct(out string username, out string password)
		{
			username = Username;
			password = Password;
		}
	}
}
