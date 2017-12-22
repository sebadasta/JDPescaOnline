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
using JDPesca.Services;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JDPesca.Controllers
{
    [Authorize(Roles = "Administrator, User")]
    public class ProductsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
            UserManager<ApplicationUser> userManager)

        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }


        // GET: Products
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {

            List<Products> products = new List<Products>();

            products = _context.Products.Include(product => product.Category).ToList();

            return View(products);
        }

        // GET: Products/Create
        [Authorize(Roles = "Administrator")]
        public  IActionResult Create()
        {

            List<SelectListItem> CatList = new List<SelectListItem>();


            var categories =  _context.Categories.ToList();



            foreach (var item in categories)
            {

                var NewItem = new SelectListItem();

                NewItem.Value = item.CategoriesID.ToString();
                NewItem.Text = item.CategoryName;

                CatList.Add(NewItem);
            }

            ViewBag.CatList = CatList;

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductEditViewModel createModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createModel);
            }

            var product = new Products();

            product = createModel.Products;

            var cate = await _context.Categories
                                     .SingleOrDefaultAsync(m => m.CategoriesID == createModel.CategoryID);


            product.Category = new Categories();
            product.Category = cate;


            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(pro => pro.Category)
                 .SingleOrDefaultAsync(m => m.ProductsID == id);
          
            if (product == null)
            {
                return NotFound();
            }


            return View(product);
        }


        // GET: Products/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<SelectListItem> CatList = new List<SelectListItem>();


            var categories = _context.Categories.ToList();

            foreach (var item in categories)
            {

                var NewItem = new SelectListItem();

                NewItem.Value = item.CategoriesID.ToString();
                NewItem.Text = item.CategoryName;

                CatList.Add(NewItem);
            }


            ViewBag.CatList = CatList;


            var product = await _context.Products.Include(pro => pro.Category).SingleOrDefaultAsync(
                m => m.ProductsID == id);
            if (product == null)
            {
                return NotFound();
            }

            var editProd = new ProductEditViewModel();

            editProd.Products = product;
            editProd.CategoryID = product.Category.CategoriesID;


            return View(editProd);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductEditViewModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editModel);
            }

            // Fetch Contact from DB to get OwnerID.
            var product = await _context.Products.Include(pro => pro.Category).SingleOrDefaultAsync(m => m.ProductsID == id);
            if (product == null)
            {
                return NotFound();
            }


            product.Name = editModel.Products.Name;
            product.Description = editModel.Products.Description;
            product.Price = editModel.Products.Price;
            product.Status = editModel.Products.Status;
            product.Image1 = editModel.Products.Image1;
            product.Image2 = editModel.Products.Image2;
            product.Image3 = editModel.Products.Image3;

            var cate = await _context.Categories
                                     .SingleOrDefaultAsync(m => m.CategoriesID == editModel.CategoryID);


            product.Category = new Categories();
            product.Category = cate;


            _context.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.Products.Include(pro => pro.Category).SingleOrDefaultAsync(
                m => m.ProductsID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }



        // POST: Products/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductsID == id);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
