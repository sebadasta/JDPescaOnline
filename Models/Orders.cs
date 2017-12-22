using System;
using System.ComponentModel.DataAnnotations;
using JDPesca.Models;
using System.Collections.Generic;


namespace JDPesca.Models
{
    public class Orders
    {
        [Display(Name = "#Orden")]
        public int OrdersID { get; set; }

        public string UserId { get; set; }

        public string Notes { get; set; }

        public string Status { get; set; }

    }


}
