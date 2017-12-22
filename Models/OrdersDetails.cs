using System;
using System.ComponentModel.DataAnnotations;
using JDPesca.Models;
using System.Collections.Generic;


namespace JDPesca.Models
{
    public class OrdersDetails
    {
        public int OrdersDetailsID { get; set; }

        public int OrdersID { get; set; }

        public int ProductID { get; set; }

        public int Amount { get; set; }

    }


}
