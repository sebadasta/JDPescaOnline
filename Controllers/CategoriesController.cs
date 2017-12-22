using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using JDPesca.Models;
using JDPesca.Data;
using JDPesca.Authorization;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JDPesca.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CategoriesController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public IList<Products> ProdList;

        public CategoriesController(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }


        // GET: Categories
        public async Task<IActionResult> Index()
        {

            var categories = from c in _context.Categories
                           select c;


            return View(await categories.ToListAsync());
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categories editModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editModel);
            }


            var category = new Categories();

            category.CategoryName = editModel.CategoryName;

            _context.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.SingleOrDefaultAsync(
                m => m.CategoriesID == id);
            if (category == null)
            {
                return NotFound();
            }


            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Categories editModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editModel);
            }

            // Fetch Contact from DB to get OwnerID.
            var category = await _context.Categories.SingleOrDefaultAsync(m => m.CategoriesID == id);
            if (category == null)
            {
                return NotFound();
            }

            category.CategoryName = editModel.CategoryName;

            _context.Update(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.SingleOrDefaultAsync(m => m.CategoriesID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(m => m.CategoriesID == id);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        // GET: Categories/openProducts/Cat1
        public async Task<IActionResult> openProducts(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            ProdList = await (from p in _context.Products.Include(pro => pro.Category)
                              where p.Category.CategoriesID == id
                        select p).ToListAsync();

            

            if (ProdList == null)
            {
                return NotFound();
            }


            return View(ProdList);
        }


    }
}
