using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookCatalog.Models
{
	public class Genre
	{
		[Key]
		public int GenreId { get; set; }

		[Required]
		[Display(Name = "Genre")]
		[StringLength(100, MinimumLength = 1)]
		public string GenreName { get; set; }
	}
}