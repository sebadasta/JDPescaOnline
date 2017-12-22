using System;
using System.ComponentModel.DataAnnotations;
using JDPesca.Models;
using System.Collections.Generic;


namespace JDPesca.Models
{
    public class ShoppingBasket
    {

        public int ShoppingBasketID { get; set; }

        public string UserID { get; set; }

        public int ProductID { get; set; }

        public int Amount { get; set; }

    }


}
