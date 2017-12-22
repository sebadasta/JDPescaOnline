using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JDPesca.Models;

namespace JDPesca.Models.OrdersViewModels
{
    public class OrderDetailViewModel
    {

        public IList<Products> Products { get; set; }

        public Orders Orders { get; set; }

        public IList<OrdersDetails> OrdersDetails { get; set; }

        public string UserName { get; set; }


    }


}
