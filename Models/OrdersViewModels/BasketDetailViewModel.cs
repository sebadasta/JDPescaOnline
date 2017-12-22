using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JDPesca.Models;

namespace JDPesca.Models.OrdersViewModels
{
    public class BasketDetailViewModel
    {

        public int ShoppingBasketID { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string Price { get; set; }

        public int Amount { get; set; }

        public int SubTotal { get; set; }



    }


}
