using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JDPesca.Models.OrdersViewModels
{
    public class IndexViewModel
    {


        public Orders Orders { get; set; }

        [Display(Name = "Cliente")]
        public string User { get; set; }

        public OrdersDetails OrdersDetail { get; set; }



    }


}
