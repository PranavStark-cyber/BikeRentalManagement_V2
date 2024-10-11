using BikeRentalManagement_V2;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRentalManagement_V2
{
    public class BikeRepository
    {

        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BikeRentalManagement;TrustServerCertificate=True;Integrated Security=True ";



        public string CapitalizeBrand(string brand)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(brand.ToLower());
        }
        public decimal ValidateBikeRentalPrice()
        {
            decimal rentalprice;
            while (true)
            {
                Console.WriteLine("Enter the rental price");
                if (decimal.TryParse(Console.ReadLine(), out rentalprice) && rentalprice > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invaild number enter the positive number");
                }


            }
            return rentalprice;
        }
        public void Addbike(Bike bike)
        {
            string query = "INSERT INTO Bikes(BikeId,Brand,Model,RentalPrice)VALUES(@BikeId,@brand,@model,@rentalprice)";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@BikeId", CapitalizeBrand(bike.BikeId));
                     command.Parameters.AddWithValue("@brand", CapitalizeBrand(bike.Brand));
                        command.Parameters.AddWithValue("@model", bike.Model);
                        command.Parameters.AddWithValue("@rentalprice", bike.RentalPrice);
                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("bike addded suceesfully");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error adding bike :{ex.Message}");
                    }
                }
            }
        }

        public List<Bike> Getallbike()
        {
            List<Bike> bikes = new List<Bike>();
            string query = "SELECT * FROM Bikes";
            using (var con = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bikes.Add(new Bike(
                                reader.GetString(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetDecimal(3)

                               ));
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"error retriving bikes{ex.Message}");
                    }
                }
            }
            return bikes;
        }


        public void UpdateBike(Bike bike)
        {
         
            string query = "UPDATE Bikes SET Brand = @Brand, Model = @Model, RentalPrice = @RentalPrice WHERE BikeId = @BikeId";
            using (var con = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, con))
                {
                    try
                    {
                        command.Parameters.AddWithValue("BikeId", bike.BikeId);
                        command.Parameters.AddWithValue("@Brand", CapitalizeBrand(bike.Brand));
                        command.Parameters.AddWithValue("@Model", bike.Model);
                        command.Parameters.AddWithValue("@RentalPrice", bike.RentalPrice);
                        con.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("bike update addded suceesfully");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error adding bike :{ex.Message}");
                    }
                }
            }
        }

        public void Deletebike(string bikeid)
        {
            string query = "DELETE FROM Bikes WHERE BikeId =@BikeId";
            using (var con = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, con))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@BikeId", bikeid);
                        con.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("sccuessfully deleted");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deleteing bike :{ex.Message}");
                    }
                }
            }
        }


        public Bike GetBikebyid(string bikeid)
        {
            Bike bike = null;
            string query = "SELECT * FROM Bikes  WHERE BikeId =@BikeId";
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@BikeId", bikeid);
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bike = new Bike(
                              reader.GetString(0),
                              reader.GetString(1),
                              reader.GetString(2),
                              reader.GetDecimal(3)
                              );
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error not find bike :{ex.Message}");
                    }
                }
            }
            return bike;
        }
    }
}