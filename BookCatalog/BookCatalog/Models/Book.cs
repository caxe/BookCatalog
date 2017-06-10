using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookCatalog.Models
{
	public class Book
	{
		public int BookId { get; set; }

		[Required]
		[StringLength(300, MinimumLength = 1)]
		public string Title { get; set; }

		[Required]
		[Display(Name = "Release Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime ReleaseDate { get; set; }

		public int AuthorId { get; set; }
		public virtual Author Author { get; set; }

		public int GenreId { get; set; }
		public virtual Genre Genre { get; set; }

		[StringLength(500, MinimumLength = 1)]
		public string Description { get; set; }
	}
}