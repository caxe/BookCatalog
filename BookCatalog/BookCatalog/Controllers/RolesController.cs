using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using BookCatalog.Models;

namespace MvcBooks.Controllers
{
	public class RolesController : Controller
	{
		ApplicationDbContext ctx = new ApplicationDbContext();

		// GET: Roles
		[Authorize(Roles = "Admin")]
		public ActionResult Index()
		{
			var roles = ctx.Roles.ToList();

			return View(roles);
		}

		// GET: Roles/Details/5
		[Authorize(Roles = "Admin")]
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Roles/Create
		[Authorize(Roles = "Admin")]
		public ActionResult Create()
		{
			return View();
		}

		// POST: Roles/Create
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				if (ModelState.IsValid)
				{
					ctx.Roles.Add(new IdentityRole { Name = collection["RoleName"].ToString() });
					ctx.SaveChanges();
				}
				return RedirectToAction("Index");
			} catch
			{
				return View();
			}
		}

		// GET: Roles/Edit/5
		[Authorize(Roles = "Admin")]
		public ActionResult Edit(string id)
		{
			if (String.IsNullOrEmpty(id))
			{
				return HttpNotFound();
			}
			var role = ctx.Roles.Find(id);
			if (role == null)
			{
				return HttpNotFound();
			}

			return View(role);
		}

		// POST: Roles/Edit/5
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public ActionResult Edit(IdentityRole role)
		{
			try
			{
				if (ModelState.IsValid)
				{
					ctx.Entry(role).State = EntityState.Modified;
					ctx.SaveChanges();
				}
				return RedirectToAction("Index");
			} catch
			{
				return View();
			}
		}

		// GET: Roles/Delete/5
		[Authorize(Roles = "Admin")]
		public ActionResult Delete(string id)
		{
			if (String.IsNullOrEmpty(id))
			{
				return HttpNotFound();
			}
			var role = ctx.Roles.Find(id);
			if (role == null)
			{
				return HttpNotFound();
			}

			return View(role);
		}

		// POST: Roles/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public ActionResult Delete(string id, FormCollection collection)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var role = ctx.Roles.Find(id);
					ctx.Roles.Remove(role);
					ctx.SaveChanges();
				}

				return RedirectToAction("Index");
			} catch
			{
				return View();
			}
		}

		[Authorize(Roles = "Admin")]
		public ActionResult ManageRoleToUser()
		{
			var listRole = ctx.Roles.Select(e => new SelectListItem { Text = e.Name, Value = e.Name });
			ViewBag.ListRoleName = listRole;

			return View();
		}

		[Authorize(Roles = "Admin")]
		public ActionResult AddRoleToUser(string UserName, string RoleName)
		{
			IdentityUser user = ctx.Users.Where(e => e.UserName == UserName).FirstOrDefault();

			var _UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
			_UserManager.AddToRole(user.Id, RoleName);

			var listRole = ctx.Roles.Select(e => new SelectListItem { Text = e.Name, Value = e.Name });
			ViewBag.ListRoleName = listRole;

			return View("ManageRoleToUser");
		}
	}
}
