using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JDPesca.Models;

namespace JDPesca.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<JDPesca.Models.Contact> Contact { get; set; }

        public DbSet<JDPesca.Models.Categories> Categories { get; set; }

        public DbSet<JDPesca.Models.Products> Products { get; set; }

        public DbSet<JDPesca.Models.Orders> Orders { get; set; }

        public DbSet<JDPesca.Models.OrdersDetails> OrderDetails { get; set; }
        public DbSet<JDPesca.Models.ShoppingBasket> ShoppingBasket { get; set; }



        }
    }
