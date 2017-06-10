using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookCatalog.Models;

namespace BookCatalog.GlobalMethods
{
	public class Load
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		public SelectList LoadDropDownGenre(object selectedGenre = null)
		{
			var listGenre = from g in db.Genres select g;

			return new SelectList(listGenre, "GenreId", "GenreName", selectedGenre);
		}
	}
}