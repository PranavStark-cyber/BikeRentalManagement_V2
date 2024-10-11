using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRentalManagement_V2
{
    public class Bike
    {
        public string BikeId  {get ;set;}
        public string 	Brand   {get ;set;}
        public string Model  { get; set; }
        public decimal RentalPrice   { get; set; }


        public Bike(string bikeid, string brand, string model, decimal renatlprice)
        {
            BikeId = bikeid;
            Brand = brand;
            Model = model;
            RentalPrice = renatlprice;
            
        }


    }
}
