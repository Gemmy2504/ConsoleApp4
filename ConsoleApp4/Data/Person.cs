using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Data
{
    internal class Person
    {
        public string? FirstName { get; set; }
        public string SecName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public double? SSN { get; set; }//should be int but return exception
        public double? Phone { get; set; }//should be int but return exception
        public string Address { get; set; }
        public string? City {get;set;} // government 

    }
   
}
