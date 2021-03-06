﻿using System;
using System.ComponentModel.DataAnnotations;
using JDPesca.Models;
using System.Collections.Generic;


namespace JDPesca.Models
{
    public class Products
    {
		public int ProductsID { get; set; }

        [Required]
		public string Name { get; set; }
		public string Description { get; set; }
        		
        public string Price { get; set; }

        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }

        [Required]
        public string Status { get; set; }

        public Categories Category { get; set; }

       
	}


    }

