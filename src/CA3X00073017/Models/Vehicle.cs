//x00073017

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CA3X00073017.Models
{
    //enum list that represents the vehicle types
    // has a display for a selection list
    public enum VechicleCategory
    {
        [Display(Name = "Car")]
        Car,
        [Display(Name = "Public Service Vehicle")]
        PublicServiceVechicle,
        [Display(Name = "Bus")]
        Bus,
        [Display(Name = "Goods")]
        Goods
    }
    public class Vehicle

    {
        //used a boolean so it would be easier to use a check box in the form
        [Display(Name = "Electroinc Tag")]
        public bool ElectronicTag { get; set; }
        //used for displaying the toll amount
        [Display (Name = "Toll Amount")]
        public double Toll { get; internal set; }
        [Display (Name = "Vehicle Type")]
        public VechicleCategory VehicleType {get; set;}

        //given a vehicle type and tag bool calucate the toll

        public double CalculateToll(VechicleCategory vechicleType, bool electronicTag)
        {
            double tollCharge = 0.0;

            //visual setup the project using .json files instead of .config files
            //did not know how to read from them

            //used an if else to calculate toll based on vehicle type
            if(vechicleType == VechicleCategory.Car)
            {
                tollCharge = 2.00;
            } else if (vechicleType == VechicleCategory.PublicServiceVechicle)
            {
                tollCharge = 2.00;
            } else if (vechicleType == VechicleCategory.Bus)
            {
                tollCharge = 2.80;
            } else if (vechicleType == VechicleCategory.Goods)
            {
                tollCharge = 4.10;
            }

            //after vehicle charge check for tag
            if (electronicTag)
            {
                tollCharge *= 0.8;
            }

            return tollCharge;
        }
    }
}
