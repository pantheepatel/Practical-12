using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task3.Models
{
    public class CreateViewClass
    {
        //DOB, MobileNumber, Address, Salary
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public DateTime DOB { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
    }
}