using System.Collections.Generic;
using System.Data.SqlClient;

namespace Net5.Fundamentals.Data.MVC.Data
{
    public class Database
    {
        public List<Customer> ListCustomers()
        {
            List<Customer> customers = new List<Customer>();

            string strConn = "Data Source=.;Initial Catalog=Pharmacy;Persist Security Info=True;User ID=sa;Password=Password1234";

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string querySql = @"
                SELECT [CustomerCode]
                    ,[CustomerName]
                    ,[CustomerAddress]
                    ,[DistrictCode]
                    ,[Sex]
                    ,[DNI]
                    ,[RUC]
                    ,[Telephone]
                    ,[Mobile]
                FROM[dbo].[Customer]
            ";
                using (SqlCommand cmd = new SqlCommand(querySql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine($"{reader[0]},{reader[1]},{reader[2]},{reader[3]},{reader[4]},{reader[5]},{reader[6]},{reader[7]},{reader[8]}");
                            Customer customer = new Customer();
                            customer.CustomerCode = reader.GetString(0);
                            customer.CustomerName = reader.GetString(1);
                            customer.CustomerAddress = reader.GetString(2);
                            customer.DistrictCode = reader.GetString(3);
                            customer.Sex = reader.GetString(4);
                            customer.Dni = reader.GetString(5);
                            customer.Ruc = reader.GetString(6);
                            customer.Telephone = reader.GetInt32(7);
                            customer.Mobile = reader.GetInt32(8);

                            customers.Add(customer);
                        }
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return customers;
        }
    }
}
