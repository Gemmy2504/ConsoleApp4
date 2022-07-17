using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Data
{
    internal class Car
    {

        public string License { get; set; }
        public string LicenseLetter { get; set; }
        public double? LicenceNumber { get; set; }//should be int but throw exception
        public string Company { get; set; }
        public double? Model { get; set; }//should be int but throw exception
        public string Color { get; set; }
        public string LicenseAuthority { get; set; }
        public double? ChassisNumber { get; set; }//should be int but throw exception
        public double? MotorNumber { get; set; }//should be int but throw exception
        public string BackMarks { get; set; }
        public string FrontMarks { get; set; }
        public string SideMarks { get; set; }
        public string InnerMarks { get; set; }
        public string LicenseStart { get; set; }
        public string LicenseExpire { get; set; }
        public string PhotoName { get; set; }


        ////////////////////////
        ///

        public Person owner = new();
        public List<Person> Drivers= new ();


    }
}
