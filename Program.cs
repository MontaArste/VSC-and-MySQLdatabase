using System;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace VSC_DAtabase
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "server=localhost;port=3306;database=WebShop;user=user;password=tyabWoff32";
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            MySqlCommand cmd = new MySqlCommand(@"SELECT * FROM suppliers
                JOIN Products ON products.supplierID = idSuppliers
                WHERE idSuppliers = 1; ", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //uint id = (uint)reader[0];
                string name = (string)reader[1];
                string product= (string)reader[6];
                decimal price = (decimal)reader[8];


                Console.WriteLine($"{name} {product} {price}");
            }
            reader.Close();

            //cmd.ExecuteNonQuery(); // For INSERT, and others that do not return dataset.

            //double result = (double)cmd.ExecuteScalar(); // For single value returned.

            conn.Close();
        }
    }
}
