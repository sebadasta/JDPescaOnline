﻿using System;
namespace JDPesca.Models
{
    public class Contact
    {
		public int ContactId { get; set; }

        // user ID from AspNetUser table
        public string OwnerID { get; set; }

		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string Email { get; set; }
	}


    }

