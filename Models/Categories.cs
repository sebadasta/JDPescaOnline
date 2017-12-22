using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace JDPesca.Models
{
    public class Categories
    {
        public int CategoriesID { get; set; }

        [Required]
		public string CategoryName { get; set; }


	}


    }

