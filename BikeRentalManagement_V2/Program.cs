using BikeRentalManagement_V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRentalManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {



            BikeRepository bikerepository = new BikeRepository();
            int option;

            do
            {


                Console.WriteLine("Bike Rental Management System:");
                Console.WriteLine("1. Add a Bike");
                Console.WriteLine("2. View All Bikes");
                Console.WriteLine("3. Update a Bike");
                Console.WriteLine("4. Delete a Bike");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an option:");
                option = int.Parse(Console.ReadLine());


                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter Bike Id");
                        string bikeid = Console.ReadLine();
                        Console.WriteLine("Enter Bike Brand");
                        string bikebrand = Console.ReadLine();
                        Console.WriteLine("Enter Bike model");
                        string bikemodel = Console.ReadLine();
                        decimal bikerentalprice = bikerepository.ValidateBikeRentalPrice();

                        Bike newbike = new Bike(bikeid, bikebrand, bikemodel, bikerentalprice);
                        bikerepository.Addbike(newbike);

                        break;

                    case 2:
                        var bikes = bikerepository.Getallbike();

                        foreach (var bike in bikes)
                        {
                            Console.WriteLine(bike);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter the Bike ID to update:");
                        string updateid = Console.ReadLine();
                        var bikeupdate = bikerepository.GetBikebyid(updateid);
                        Console.WriteLine("Enter  newBike Brand");
                        string newbikebrand = Console.ReadLine();
                        bikeupdate.Brand = newbikebrand;
                        Console.WriteLine("Enter  newBike model");
                        string newbikemodel = Console.ReadLine();
                        bikeupdate.Model = newbikemodel;
                        decimal newbikerentalprice = bikerepository.ValidateBikeRentalPrice();
                        bikeupdate.RentalPrice = newbikerentalprice;



                        bikerepository.UpdateBike(bikeupdate);
                        break;

                    case 4:
                        Console.WriteLine("Enter the Bike ID to Delete:");
                        string deleteid = Console.ReadLine();
                        bikerepository.Deletebike(deleteid);

                        break;

                    case 5:

                        Console.WriteLine("exiting program ,thank you");
                        break;

                    default:
                        Console.WriteLine("invalid number please enter 1 to 5");

                        break;


                }


                Console.WriteLine();

            } while (option != 5);
        }
    }
}