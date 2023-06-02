using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.Design;

namespace Datadata
{
    class Program
    {

        public static string connectionString = File.ReadAllText(@"C:\connectionfolder.txt");

        public static string sqlQuery = File.ReadAllText(@"C:\queryinput.txt");

        public static void Main()
        {
            if (sqlQuery.Contains("count"))
            {
                Count_();
            }
            else
            {
                Select();
            }
        }
        public static void Select()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string column1 = reader["column1"].ToString();
                                string column2 = reader["column2"].ToString();
                                string column3 = reader["column3"].ToString();
                                

                                Console.WriteLine("sonuc:" + column1 + column2 + column3);
                            }

                        }
                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public static void Count_()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {

                        int count = (int)command.ExecuteScalar();
                        Console.WriteLine("toplam row:" + count);

                    }
                    connection.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                }

            }
        }

  
    }

}
