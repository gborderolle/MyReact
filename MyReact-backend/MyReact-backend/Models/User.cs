using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyReact_backend.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserID { get; set; }

		[Required(ErrorMessage = "Por favor, ingrese este dato")]
		[MaxLength(50)]
		public string Username { get; set; }

		[Required(ErrorMessage = "Por favor, ingrese este dato")]
		[MaxLength(50)]
		public string Password { get; set; }


		/// <summary>
		/// *************** GENÉRICOS ***************
		/// </summary>
		public DateTime Datetime_created { get; set; } = DateTime.Now;

		[MaxLength(200)]
		public string? Comments { get; set; }

	}
}
