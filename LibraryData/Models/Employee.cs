﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Models
{
    public class Employee
    {
        public Guid EmpId { get; set; }
        public string EmployeeId {  get; set; } 
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }   
        public DateTime DateTime { get; set; }
    }
}
