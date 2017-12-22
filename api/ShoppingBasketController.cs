using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using JDPesca.Models;
using JDPesca.Models.OrdersViewModels;
using JDPesca.Data;
using Microsoft.AspNetCore.Authorization;
using JDPesca.Authorization;
using Microsoft.AspNetCore.Http;
using JDPesca.Services;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JDPesca.api
{


    public class ShoppingBasketController : Controller
    {

        private readonly ApplicationDbContext _context;


        public ShoppingBasketController(ApplicationDbContext context)
        {
            _context = context;
        }  





        [HttpGet("api/[controller]/GetItems")]
        public IEnumerable<ShoppingBasket> GetAll()
        {

            return _context.ShoppingBasket.ToList();   
        }


        [HttpGet("api/[controller]/getUserBasket")]
        public IEnumerable<BasketDetailViewModel> getUserBasket(string userID)
        {


            var items = _context.ShoppingBasket.Where(i => i.UserID == userID);

            var prods = _context.Products.ToList();
            if (items == null)
            {
                //return NotFound();
            }



            List<BasketDetailViewModel> vmList = new List<BasketDetailViewModel>();



            foreach(ShoppingBasket item in items){

                var prod = prods.FirstOrDefault(p => p.ProductsID == item.ProductID);

                var vm = new BasketDetailViewModel();

                vm.Amount = item.Amount;
                vm.Price = prod.Price;
                vm.ProductName = prod.Name;
                vm.ProductID = prod.ProductsID;
                vm.ShoppingBasketID = item.ShoppingBasketID;
                vmList.Add(vm);


            }


            return vmList;
        }


    
        [HttpPost("api/[controller]/create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] ShoppingBasket item)
        {
            _context.Add(item);

            _context.SaveChanges();

            return new ObjectResult(item);
        }



        // POST: /ShoppingBasket/DeleteItem/5
        [HttpPost("api/[controller]/DeleteItem")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteItem([FromBody]  int id)
        {



            var itemToDelete = await _context.ShoppingBasket.SingleOrDefaultAsync(m => m.ShoppingBasketID == id);


            _context.ShoppingBasket.Remove(itemToDelete);
            await _context.SaveChangesAsync();
            //return new ObjectResult(itemToDelete);
            return new NoContentResult();

           
        }

      

        [HttpGet("api/[controller]/EmptyBasket")]
        [AllowAnonymous]
        public string EmptyBasket(string userID)
        {

            var items = _context.ShoppingBasket.Where(i => i.UserID == userID);

            if (items.Count() == 0)
            return "El Carrito ya esta vacio!";


            try
            {
                _context.ShoppingBasket.Where(i => i.UserID == userID).ToList().ForEach(p => _context.ShoppingBasket.Remove(p));

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Success";

        }

    }
}
