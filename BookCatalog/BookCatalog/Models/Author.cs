using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookCatalog.Models
{
	public class Author
	{
		[Key]
		public int AuthorId { get; set; }

		[Required]
		[Display(Name = "First Name")]
		[StringLength(200, MinimumLength = 1)]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		[StringLength(200, MinimumLength = 1)]
		public string LastName { get; set; }
	}
}