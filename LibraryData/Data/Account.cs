﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Data
{
    public class Account
    {
        public Guid AccId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }    
        public string FullName {  get; set; }
        public string Email { get; set; }   
    }
}
