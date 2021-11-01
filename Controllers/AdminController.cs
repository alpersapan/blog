using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using blog.Data;
using blog.Models;
using System.Collections.Generic;

namespace blog.Controllers
{
    public class AdminController : Controller
    {
        private readonly BlogDbContext _context;

        public AdminController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: Admin
        [Authorize]
        [Route("{controller}/index")]
        [Route("{controller}")]
        public async Task<IActionResult> Index()
        {
            return View("~/Views/Admin/Blogs/Index.cshtml",await _context.BlogCategoryUsers.ToListAsync());
        }

        #region BLOGS

        // GET: Admin/Blogs
        [Authorize]
        [Route("{controller}/blogs/index")]
        [Route("{controller}/blogs")]
        public async Task<IActionResult> BlogIndex()
        {
            return View("~/Views/Admin/Blogs/Index.cshtml",await _context.BlogCategoryUsers.ToListAsync());
        }

        // GET: Admin/Blogs/Details/5
        [Authorize]
        [Route("{controller}/blogs/details/{id}")]
        public async Task<IActionResult> BlogDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.BlogCategoryUsers.FirstOrDefaultAsync(m => m.BlogId == id);
            
            if (blog == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/Blogs/Details.cshtml",blog);
        }

        // GET: Admin/Blogs/Create
        [Authorize]
        [Route("{controller}/blogs/create")]
        public IActionResult BlogCreate()
        {
            List<SelectListItem> kullanicilar = (from x in _context.Users.ToList()
            select new SelectListItem{Text = x.UserName,Value = x.UserId.ToString()}).ToList();
            List<SelectListItem> kategoriler = (from x in _context.Categories.ToList()
            select new SelectListItem{Text = x.CategoryName,Value = x.CategoryId.ToString()}).ToList();
            ViewBag.kullanicilar = kullanicilar;
            ViewBag.kategoriler = kategoriler;
            return View("~/Views/Admin/Blogs/Create.cshtml");
        }

        // POST: Admin/Blogs/Create
        [Authorize]
        [HttpPost]
        [Route("{controller}/blogs/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BlogCreate(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction("index","admin");
            }
            return View("~/Views/Admin/Blogs/Create.cshtml",blog);
        }

        // GET: Admin/Blogs/Edit/5
        [Authorize]
        [Route("{controller}/blogs/edit/{id}")]
        public async Task<IActionResult> BlogEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var blog = await _context.Blogs.FirstOrDefaultAsync(m=>m.BlogId == id);
            List<SelectListItem> kullanicilar = (from x in _context.Users.ToList()
            select new SelectListItem{Text = x.UserName,Value = x.UserId.ToString()}).ToList();
            List<SelectListItem> kategoriler = (from x in _context.Categories.ToList()
            select new SelectListItem{Text = x.CategoryName,Value = x.CategoryId.ToString()}).ToList();
            ViewBag.kullanicilar = kullanicilar;
            ViewBag.kategoriler = kategoriler;
            if (blog == null)   
            {
                return NotFound();
            }
            return View("~/Views/Admin/Blogs/Edit.cshtml",blog);
        }

        // POST: Admin/Blogs/Edit/5
        [Authorize]
        [HttpPost]
        [Route("{controller}/blogs/edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BlogEdit(int id, Blog blog)
        {
            if (id != blog.BlogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.BlogId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("index","admin");
            }
            return View(blog);
        }

        // GET: Admin/Blogs/Delete/5
        [Route("{controller}/blogs/delete/{id}")]
        public async Task<IActionResult> BlogDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/Blogs/Delete.cshtml",blog);
        }

        // POST: Admin/Blogs/Delete/5
        [Authorize]
        [HttpPost, ActionName("BlogDelete")]
        [Route("{controller}/blogs/delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BlogDeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("index","admin");
        }

        [Authorize]
        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.BlogId == id);
        }

        #endregion

        #region CATEGORIES
        
        // GET: Admin/Categories
        [Authorize]
        [Route("{controller}/categories/index")]
        [Route("{controller}/categories")]
        public async Task<IActionResult> CategoryIndex()
        {
            return View("~/Views/Admin/Categories/Index.cshtml",await _context.Categories.ToListAsync());
        }

        // GET: Admin/Categories/Create
        [Authorize]
        [HttpGet]
        [Route("{controller}/categories/create")]
        public IActionResult CategoryCreate()
        {
            return View("~/Views/Admin/Categories/Create.cshtml");
        }

        // POST: Admin/Categories/Create
        [Authorize]
        [HttpPost]
        [Route("{controller}/categories/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryCreate(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("categories","admin");
            }
            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        [Authorize]
        [Route("{controller}/categories/edit/{id}")]
        public async Task<IActionResult> CategoryEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _context.Categories.FirstOrDefaultAsync(m=>m.CategoryId == id);
            if (category == null)   
            {
                return NotFound();
            }
            return View("~/Views/Admin/Categories/Edit.cshtml",category);
        }

        // POST: Admin/Categories/Edit/5
        [Authorize]
        [HttpPost]
        [Route("{controller}/categories/edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryEdit(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("categories","admin");
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        [Authorize]
        [Route("{controller}/categories/delete/{id}")]
        public async Task<IActionResult> CategoryDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/Categories/Delete.cshtml",category);
        }

        // POST: Admin/Categories/Delete/5
        [Authorize]
        [HttpPost, ActionName("categoryDelete")]
        [Route("{controller}/categories/delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryDeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("categories","admin");
        }

        [Authorize]
        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }

        #endregion

        #region USERS
        
        // GET: Admin/Users
        [Authorize]
        [Route("{controller}/users/index")]
        [Route("{controller}/users")]
        public async Task<IActionResult> UserIndex()
        {
            return View("~/Views/Admin/Users/Index.cshtml",await _context.Users.ToListAsync());
        }

        // GET: Admin/Users/Create
        [Authorize]
        [HttpGet]
        [Route("{controller}/users/create")]
        public IActionResult UserCreate()
        {
            return View("~/Views/Admin/Users/Create.cshtml");
        }

        // POST: Admin/Users/Create
        [Authorize]
        [HttpPost]
        [Route("{controller}/users/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserCreate(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("users","admin");
            }
            return View(user);
        }

        // GET: Admin/Users/Edit/5
        [Authorize]
        [Route("{controller}/users/edit/{id}")]
        public async Task<IActionResult> UserEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FirstOrDefaultAsync(m=>m.UserId == id);
            if (user == null)   
            {
                return NotFound();
            }
            return View("~/Views/Admin/Users/Edit.cshtml",user);
        }

        // POST: Admin/Users/Edit/5
        [Authorize]
        [HttpPost]
        [Route("{controller}/users/edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserEdit(int id, User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("users","admin");
            }
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        [Authorize]
        [Route("{controller}/users/delete/{id}")]
        public async Task<IActionResult> UserDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/Users/Delete.cshtml",user);
        }

        // POST: Admin/Users/Delete/5
        [Authorize]
        [HttpPost, ActionName("userDelete")]
        [Route("{controller}/users/delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserDeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("users","admin");
        }

        [Authorize]
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        #endregion
    }
}
