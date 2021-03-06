﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    internal class Program
    {
        private static void Main()
        {
            //This is intentionally bad : (  Let's Refactor!
            var conn = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;");

            var cmd = conn.CreateCommand();
            cmd.CommandText = "select * from Products";
            /*
             * cmd.CommandText = "Select * from Invoices";
             */
            var reader = cmd.ExecuteReader();
            var products = new List<Product>();

            //TODO: Replace with Dapper
            while (reader.Read())
            {
                var prod = new Product
                {
                    Name = reader["Name"].ToString()
                };
                products.Add(prod);
            }
            conn.Dispose();
            Console.WriteLine("Products Loaded!");
            for (var i =0; i< products.Count; i++)
            {
                Console.WriteLine(products[i].Name);
            }
        }
    }
    public class Product
    {
        public string Name { get; set; }
    }
}
