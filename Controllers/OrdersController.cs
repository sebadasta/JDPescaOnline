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


namespace JDPesca.Controllers
{
    [Authorize(Roles = "Administrator, User")]
    public class OrdersController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;


        public OrdersController(
ApplicationDbContext context,
IAuthorizationService authorizationService,
UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }


        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {

            IList<Models.OrdersViewModels.IndexViewModel> IOrder = new List<Models.OrdersViewModels.IndexViewModel>();
  

            var user = await _userManager.GetUserAsync(User);

            var Rol = await _userManager.GetRolesAsync(user);

            var Ordenes = from c in _context.Orders
                          select c;

            if(Rol.FirstOrDefault() == "User"){

                   Ordenes = from c in _context.Orders
                              where c.UserId == user.Id
                              select c;
   }

           
            var OrderList = await Ordenes.ToListAsync();

            foreach(Orders order in OrderList){

                var Orderuser = await _userManager.FindByIdAsync(order.UserId.ToString());

                IOrder.Add(new Models.OrdersViewModels.IndexViewModel{Orders = order,
                
                    User = Orderuser.UserName
                
                });

            }

            return View(IOrder);

        }

        // GET: /<controller>/Details
        public async Task<IActionResult> Details(int? id)
        {

            IList<Products> ProdList = new List<Products>();

            var vm = new JDPesca.Models.OrdersViewModels.OrderDetailViewModel();



       
            var AllOrder = from o in _context.Orders
                        select o;

            var Order = AllOrder.Where(s => s.OrdersID == id).FirstOrDefault();


            var Orders = from o in _context.OrderDetails
                      select o;

            Orders = Orders.Where(s => s.OrdersID == id);

            var OrderList = await Orders.ToListAsync();


            var AllProds = from p in _context.Products
                         select p;

           var AllProdList = _context.Products.Include(product => product.Category).ToList();


            var user = await _userManager.FindByIdAsync(Order.UserId.ToString());


            foreach (OrdersDetails order in OrderList)
            {

                var prod = AllProds.Where(s => s.ProductsID == order.ProductID).FirstOrDefault();

                ProdList.Add(prod);

            }

            vm.Products = ProdList;
            vm.Orders = Order;
            vm.OrdersDetails = Orders.ToList();
            vm.UserName = user.UserName;

            return View(vm);

        }




        // GET: Orders/Create

        public async Task<IActionResult> Create(string id)
        {



            var newOrder = new Orders();

            newOrder.UserId = id;
            newOrder.Status = "Pendiente";

            _context.Add(newOrder);
           
            await _context.SaveChangesAsync();



            var items = _context.ShoppingBasket.Where(i => i.UserID == id).ToList();

            foreach(ShoppingBasket item in items){

                var newOrderDetail = new OrdersDetails();

                newOrderDetail.OrdersID = newOrder.OrdersID;
                newOrderDetail.ProductID = item.ProductID;
                newOrderDetail.Amount = item.Amount;

                _context.Add(newOrderDetail);

            }

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


            _context.OrderDetails.Where(i => i.OrdersID == id).ToList().ForEach(p => _context.OrderDetails.Remove(p));

            var Order = await _context.Orders.SingleOrDefaultAsync(m => m.OrdersID == id);
           

            _context.Orders.Remove(Order);

            _context.SaveChanges();





            return RedirectToAction("Index"); 
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
