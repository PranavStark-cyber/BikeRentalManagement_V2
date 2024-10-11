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
        string connectionstring = "";
       


        public void Addbike(Bike bike)
        {
            var query = "INSERT INTO (BikeId,Brand,Model,RentalPrice)VALUES(@Id,@Brand,@Modal,@Rentalprice)";

            using (var connection =new SqlConnection(connectionstring))
            {
                using(var cmd = new SqlCommand(query,connection))
                {
                    cmd.Parameters.AddWithValue("@Id", bike.BikeId);
                    cmd.Parameters.AddWithValue("@Brand", bike.);
                    cmd.Parameters.AddWithValue("@Modal", bike.BikeId);
                    cmd.Parameters.AddWithValue("@Rentalprice", bike.BikeId);
                }
            }
        }
    }
}
