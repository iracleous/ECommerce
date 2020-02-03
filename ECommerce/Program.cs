using ECommerce.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ECommerce
{
    class Program
    {
        static string s1 = "Server =localhost; Database =accenture; Integrated Security=SSPI;Persist Security Info=False;"; 
        static string s2 = "Server =localhost; Database =accenture; Persist Security Info=True;User ID=sa;Password=passw0rd;";

 

        static void Main(string[] args)
        {
            Product product = new Product
            {
                Name = "education service",
                Price = 11.90m
            };
            test4(product);
            test2();
        }




        public static void test3()
        {

            int insertedItems = 0;
            using SqlConnection conn = new SqlConnection();
            conn.ConnectionString = s2;
            conn.Open();
            SqlCommand insertCommand = new SqlCommand(
                "INSERT INTO product (name, price) VALUES (@0, @1)", conn);
            insertCommand.Parameters.Add(  new SqlParameter("0", "radikia"));
            insertCommand.Parameters.Add(  new SqlParameter("1", 1.89));
            insertedItems = insertCommand.ExecuteNonQuery();
        }

        public static void test4(Product p)
        {

            int insertedItems = 0;
            using SqlConnection conn = new SqlConnection();
            conn.ConnectionString = s2;
            conn.Open();
            SqlCommand insertCommand = new SqlCommand(
                "INSERT INTO product (name, price) VALUES (@0, @1)", conn);
            insertCommand.Parameters.Add(new SqlParameter("0", p.Name));
            insertCommand.Parameters.Add(new SqlParameter("1", p.Price));
            insertedItems = insertCommand.ExecuteNonQuery();
        }


        public static void test2()
        {
            using SqlConnection conn = new SqlConnection
            {
                ConnectionString = s2
            };
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * from product", conn);
            using SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("FirstColumn\tSecond Column");
            while (reader.Read())
            {
                Console.WriteLine(
                $"{reader[0]} \t | {reader[1]} \t  | {reader[2]} \t");
            }
        }


        public static void test()
        {
            Product product = new Product
            {
                Name = "chocolates",
                Price = 20
            };

            Customer customer = new Customer
            {
                FirstName = "Dimitris",
                LastName = "Iracleous",
                Age = 18
            };

            Order order = new Order
            {
                Customer = customer,
                Products = new List<Product>(),
                Date = DateTime.Now
            };

            order.Products.Add(product);

            order.Print();

        }
    }
}
