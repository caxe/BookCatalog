using Microsoft.AspNet.Identity.EntityFramework;

namespace BookCatalog.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
	}

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection")
		{
		}

		public System.Data.Entity.DbSet<Genre> Genres { get; set; }
		public System.Data.Entity.DbSet<Book> Books { get; set; }
		public System.Data.Entity.DbSet<Author> Authors { get; set; }

		//public System.Data.Entity.DbSet<ApplicationUser> ApplicationUsers { get; set; }
	}
}