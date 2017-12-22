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

namespace JDPesca.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class ShoppingBasketService : IShoppingBasketService
    {

        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;


        public ShoppingBasketService(ApplicationDbContext context,
         IAuthorizationService authorizationService,
         UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
           
        }

        public Task AddItem(ShoppingBasket newItem)
        {



            _context.ShoppingBasket.Add(newItem);
             _context.SaveChangesAsync();
           





            return null;
        }
    }
}
