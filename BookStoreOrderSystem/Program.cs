using System;
using System.Collections.Generic;
using BookStoreOrderSystem.Models;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            IList<Book> myOrder = new List<Book>() { 
                new Book(){ Qty=1, Category="Crime", Title="Unsolved Crimes", UnitPrice=10.99m},
                new Book(){ Qty=1, Category="Romance", Title="A Little Love Story", UnitPrice=2.40m},
                new Book(){ Qty=1, Category="Fantasy", Title="Heresy", UnitPrice=6.80m},
                new Book(){ Qty=1, Category="Crime", Title="Jack the Ripper", UnitPrice=16.00m},
                new Book(){ Qty=1, Category="Fantasy", Title="The Tolkien Years", UnitPrice=22.90m}
            };

            Order _order = new Order();
            _order.PrintOutput(myOrder);
        }
    }
}

