//x00071017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CA3X00073017.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CA3X00073017.Controllers
{
    public class VehicleController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult TollCalculate()
        {
            try
            {
                //create a new vehicle model from the form
                Vehicle vehicle = new Vehicle();
                //due to list being numbers there is an incorrect calculation
                //calucate vehicle toll and return it to the view
                vehicle.Toll = vehicle.CalculateToll(vehicle.VehicleType, vehicle.ElectronicTag);
                return View(vehicle);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public IActionResult TollCalculate(Vehicle vehicle)
        {
            //check if the vehicle model is valid and if so recaluate and return
            if (ModelState.IsValid)
                try
                {
                    vehicle.Toll = vehicle.CalculateToll(vehicle.VehicleType, vehicle.ElectronicTag);
                    return View(vehicle);
                } catch (Exception e)
                {
                    //a general exception is due to restricted input types
                    ModelState.AddModelError("Calculation Error", e.Message);
                    //reset toll to 0 if an error occurs
                    vehicle.Toll = 0.0;
                    return View(vehicle);
                } else {
                vehicle.Toll = 0.0;
                    return View(vehicle);
             }
        }
    }
}
