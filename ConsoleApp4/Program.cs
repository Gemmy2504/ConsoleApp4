using ExcelDataReader;
using System;
using ConsoleApp4.Data;
////////////////
///
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
var stream = File.Open("test1.xlsx", FileMode.Open, FileAccess.Read);
var reader = ExcelReaderFactory.CreateReader(stream);
List<Car> Cars = new List<Car>();

// drivers starts from column 26 => 25 zero based

int driverNo(int ColumnsNo)
{
    int count = (ColumnsNo - 25);

    return (count/8);
}

/*
Person getowner(IExcelDataReader Reader)
{
    Car car1 = new();
    car1.owner.FirstName = "" + Reader.GetValue((int)OwnerEnum.ownerFirstName);
    car1.owner.SecName = "" + Reader.GetValue((int)OwnerEnum.ownerSecName);
    car1.owner.ThirdName = "" + Reader.GetValue((int)OwnerEnum.ownerThirdName);
    car1.owner.FourthName = "" + Reader.GetValue((int)OwnerEnum.ownerFourthName);
    car1.owner.SSN = "" + Reader.GetValue((int)OwnerEnum.ownerSSN);
    car1.owner.Phone = "" + Reader.GetValue((int)OwnerEnum.ownerPhone);
    car1.owner.Address = "" + Reader.GetValue(((int)OwnerEnum.ownerAddress));
    car1.owner.City = "" + Reader.GetValue(((int)OwnerEnum.ownerCity));


    return car1.owner;
}
*/
Car getInfo(IExcelDataReader Reader)
{
    Car car2 = new();
    // owner part
    car2.owner.FirstName = "" + Reader.GetValue((int)OwnerEnum.ownerFirstName);
    car2.owner.SecName = "" + Reader.GetValue((int)OwnerEnum.ownerSecName);
    car2.owner.ThirdName = "" + Reader.GetValue((int)OwnerEnum.ownerThirdName);
    car2.owner.FourthName = "" + Reader.GetValue((int)OwnerEnum.ownerFourthName);
    car2.owner.Address = "" + Reader.GetValue(((int)OwnerEnum.ownerAddress));
    car2.owner.City = "" + Reader.GetValue(((int)OwnerEnum.ownerCity));
    if(Reader.IsDBNull((int)OwnerEnum.ownerSSN))
    {
        //owner ssn is null wait for action
    }
    else
    {
        car2.owner.SSN = (double) Reader.GetValue((int)OwnerEnum.ownerSSN);
    }
    if(Reader.IsDBNull((int)OwnerEnum.ownerPhone))
    {
        //owner phone is null wait for action
    }
    else
    {
        car2.owner.Phone = (double)Reader.GetValue((int)OwnerEnum.ownerPhone);

    }
    
    
    // car part
    car2.License = "" + Reader.GetValue((int)CarEnum.carLicense);
    car2.LicenseLetter = "" + Reader.GetValue((int)CarEnum.licanseLetter);
    car2.Company = "" + Reader.GetValue(((int)CarEnum.company));
    car2.Color = "" + Reader.GetValue((int)CarEnum.color);
    car2.LicenseAuthority = "" + Reader.GetValue((int)CarEnum.Authority);
   car2.FrontMarks = "" + Reader.GetValue((int)CarEnum.frontMarks);
    car2.BackMarks = "" + Reader.GetValue((int)CarEnum.backMarks);
    car2.SideMarks = "" + Reader.GetValue((int)CarEnum.sideMarks);
    car2.InnerMarks = "" + Reader.GetValue((int)CarEnum.innerMarks);
    car2.LicenseStart = "" + Reader.GetValue(((int)CarEnum.licenseStart));
    car2.LicenseExpire = "" + Reader.GetValue(((int)CarEnum.licenseExpire));
    car2.PhotoName = "" + Reader.GetValue((int)CarEnum.photoName);
    
    if(Reader.IsDBNull((int)CarEnum.licanseNumber))
    {
            // licanse number is null wait for action
    }
    else
    {
        car2.LicenceNumber = (double)Reader.GetValue((int)CarEnum.licanseNumber);

    }
    
    if(Reader.IsDBNull((int)CarEnum.chassisNo))
    {
        // chassis no is null wait for action
    }
    else
    {
         car2.ChassisNumber = (double) Reader.GetValue((int)CarEnum.chassisNo);
    }
  
    if (Reader.IsDBNull((int)CarEnum.motorNo))
    {
        // motor no is null wait for action
    }
    else
    {
    car2.MotorNumber = (double)Reader.GetValue((int)CarEnum.motorNo);

    }
   
    if (Reader.IsDBNull((int)CarEnum.model))
    {
        // car model is null wait for action
    }
    else
    {
        car2.Model = (double)Reader.GetValue((int)CarEnum.model);

    }

   



    return car2;
}

reader.Read(); // to skip first row that contain column info

//reader.IsDBNull();  to check if the value is null


    while (reader.Read()) //Each ROW
    {
        Car car = new();
        
        
        //insert car and owner info
        //
        car = getInfo(reader);

        ///  insert drivers
         
        int dr = driverNo(reader.FieldCount); //get number of drivers

        if (dr > 0)
        {
            for (int i = 0; dr > 0; i += 8, dr--) 
            {
                Person driver = new();

                driver.FirstName = "" + reader.GetValue(((int)DriverEnum.driverFirstName + i));
                driver.SecName = "" + reader.GetValue(((int)DriverEnum.driverSecName + i));
                driver.ThirdName = "" + reader.GetValue(((int)DriverEnum.driverThirdName + i));
                driver.FourthName = "" + reader.GetValue(((int)DriverEnum.driverFourthName + i));
                driver.Address = "" + reader.GetValue(((int)DriverEnum.driverAddress + i));
                driver.City = "" + reader.GetValue(((int)DriverEnum.driverCity + i));


                if( reader.IsDBNull(((int)DriverEnum.driverSSN + i)))
                {
                    // driver ssn is Null wait for action
                }
                else
                {
                    driver.SSN = (double) reader.GetValue(((int)DriverEnum.driverSSN + i));
                }
                if( reader.IsDBNull(((int)DriverEnum.driverPhone + i)))
                {
                    //driver phone number is null wait for action
                }
                else
                {
                    driver.Phone = (double) reader.GetValue(((int)DriverEnum.driverPhone + i));
                    car.Drivers.Add(driver);
                }
                
            }

        }
       
        Cars.Add(car);
    
    Console.WriteLine(" ");
    }

    foreach(Car car in Cars)
{
    Console.WriteLine(car.owner.FirstName);
    Console.WriteLine(car.Model);
}


enum OwnerEnum
{
   ownerFirstName = 1,
    ownerSecName = 2,
    ownerThirdName = 3,
    ownerFourthName = 4,
    ownerSSN = 5,
    ownerPhone = 6,
    ownerAddress = 7,
    ownerCity = 8 // government 

}
enum CarEnum
{
    carLicense = 9,
    licanseLetter = 10,
    licanseNumber = 11,
    company = 12,
    model = 13,
    color = 14,
    Authority = 15,
    chassisNo =16,
    motorNo =17,
    backMarks = 18,
    frontMarks =19,
    sideMarks=20,
    innerMarks=21,
    licenseStart=22,
    licenseExpire=23,
    photoName=24,

}
enum DriverEnum
{
    driverFirstName = 25,
    driverSecName = 26,
    driverThirdName = 27,
    driverFourthName = 28,
    driverSSN = 29,
    driverPhone = 30,
    driverAddress = 31,
    driverCity = 32, // government 
}

/*
// for (int column = 0; column < reader.FieldCount;)
//{
    //Console.WriteLine(reader.GetString(column));//Will blow up if the value is decimal etc. 
    //Owner info
    //car.owner.FirstName = "" + reader.GetValue((int)OwnerEnum.ownerFirstName);
    //car.owner.SecName = "" + reader.GetValue((int)OwnerEnum.ownerSecName);
    //car.owner.ThirdName = "" + reader.GetValue((int)OwnerEnum.ownerThirdName);
    //car.owner.FourthName = "" + reader.GetValue((int)OwnerEnum.ownerFourthName);
    //car.owner.SSN = "" + reader.GetValue((int)OwnerEnum.ownerSSN);
    //car.owner.Phone = "" + reader.GetValue((int)OwnerEnum.ownerPhone);
    //car.owner.Address = "" + reader.GetValue(((int)OwnerEnum.ownerAddress));
    //car.owner.City = "" + reader.GetValue(((int)OwnerEnum.ownerCity));

    //  car.owner = getowner(reader);

    // Car info

    //car.License         = "" + reader.GetValue((int)CarEnum.carLicense);
    //car.LicenceNumber   = "" + reader.GetValue((int)CarEnum.licanseNumber);
    //car.LicenseLetter   = "" + reader.GetValue((int)CarEnum.licanseLetter);
    //car.Company         = "" + reader.GetValue(((int)CarEnum.company));
    //car.Model           = "" + reader.GetValue((int)CarEnum.model);
    //car.Color           = "" + reader.GetValue((int)CarEnum.color);
    //car.LicenseAuthority= "" + reader.GetValue((int)CarEnum.Authority);
    //car.ChassisNumber   = "" + reader.GetValue((int)CarEnum.chassisNo);
    //car.MotorNumber     = "" + reader.GetValue((int)CarEnum.motorNo);
    //car.FrontMarks      = "" + reader.GetValue((int)CarEnum.frontMarks);
    //car.BackMarks       = "" + reader.GetValue((int)CarEnum.backMarks);
    //car.SideMarks       = "" + reader.GetValue((int)CarEnum.sideMarks);
    //car.InnerMarks      = "" + reader.GetValue ((int)CarEnum.innerMarks);
    //car.LicenseStart    = "" + reader.GetValue(((int)CarEnum.licenseStart));
    //car.LicenseExpire   = "" + reader.GetValue(((int)CarEnum.licenseExpire));
    //car.PhotoName       = "" + reader.GetValue((int)CarEnum.photoName);

//}

do{} while (reader.NextResult()); //Move to NEXT SHEET
*/