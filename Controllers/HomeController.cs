using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using JDPesca.Models;
using JDPesca.Data;
using Microsoft.AspNetCore.Authorization;
using JDPesca.Authorization;
using Microsoft.AspNetCore.Http;
using JDPesca.Services;


namespace JDPesca.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IShoppingBasketService _ShoppingService;

        public HomeController(ApplicationDbContext context,
                 IAuthorizationService authorizationService,
                 UserManager<ApplicationUser> userManager, IShoppingBasketService ShoppingService)
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
            _ShoppingService = ShoppingService;
        }


        //[AllowAnonymous]
        public async Task<IActionResult> Index()
        {

            var products = from c in _context.Products
                           select c;


            products = products.Where(product => product.Status == "Publicado").Include(pro => pro.Category);

            var choto = await products.ToListAsync() ;

            return View(await products.ToListAsync());

        }


        public ActionResult ModalPopUp()  
        {  
            return View();  
        } 




        public async Task<IActionResult> addItem(int id)
        {
           

            ShoppingBasket newItem = new ShoppingBasket();

            var user =  _userManager.GetUserAsync(User);

            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
    
            //var newItem = new ShoppingBasket();

            newItem.UserID =  user.Id.ToString();
            newItem.ProductID = id;

            _context.ShoppingBasket.Add(newItem);
            await _context.SaveChangesAsync();



            _context.Dispose();

            return RedirectToAction("Index"); 
        
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}





