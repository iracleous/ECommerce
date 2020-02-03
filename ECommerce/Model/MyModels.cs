using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Model
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
         
        public override string ToString()
        {
            return $"Name= {Name} Price= {Price}";
        }

   
    } 
    public class Order
    {
        public List<Product> Products { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }

        public void Print()
        {
           foreach(Product product in Products)
            {
                Console.WriteLine(product.ToString());
            }
        }
        public void Print1()
        {
            Products.ForEach(product => Console.WriteLine(product));
        }
       


    } 
}
