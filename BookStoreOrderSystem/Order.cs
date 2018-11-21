using System;
using System.Collections.Generic;

namespace BookStoreOrderSystem.Models
{
    public class Order
    {
        public decimal DiscountPrice = 0.05m;
        public decimal Tax = 0.1m;
        public decimal TotalPrice = 0m;

        public void PrintOutput(IList<Book> myOrder)
        {            
            //PrintMenu();
            PrintHeader();
            PrintOrders(myOrder);
            PrintTotalCost();
        }

        public void PrintHeader()
        {
            Console.WriteLine("Your Order Description");
            Console.WriteLine("------------------------------------");
        }

        public void PrintOrders(IList<Book> orders)
        {
            foreach (var item in orders) {
                decimal itemDiscountedPrice = 0m;
                // Print item
                PrintItem(item);
                
                // Print discount
                if (item.Category.ToLower() == "crime") {
                    itemDiscountedPrice = DiscountPrice * item.UnitPrice;
                    PrintItemDiscount(itemDiscountedPrice);
                }

                // Calculate total
                TotalPrice += item.UnitPrice - itemDiscountedPrice;
            }
        }

        public void PrintItem(Book item)
        {
            Console.WriteLine("{0} x {1}\t{2:C}", item.Qty, item.Title, item.UnitPrice);
        }

        public void PrintItemDiscount(decimal itemDiscountedPrice)
        {
            Console.WriteLine("Discount 5% Off Crime\t-{0:C}", itemDiscountedPrice);
        }

        public void PrintTotalCost()
        {
            Console.WriteLine("");
            Console.WriteLine("Sub Total\t\t{0:C}", TotalPrice);
            Console.WriteLine("Tax\t\t\t{0:C}", Tax * TotalPrice);
            Console.WriteLine("TOTAL\t\t\t{0:C}", ((1m + Tax) * TotalPrice));
        }
        
        public void PrintMenu()
        {
            Console.WriteLine("        =====================================");
            Console.WriteLine("");
            Console.WriteLine("              Welcome to HS Book Store");
            Console.WriteLine("");
            Console.WriteLine("        =====================================");
            Console.WriteLine("");
            Console.WriteLine("Here are the Book List. >> Special << 5% Discount for any Crime books.");
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("No | Title                    | Category |  Price ($)|");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(" 1 | Unsolved Crime           | Crime    |     10.99 |");
            Console.WriteLine(" 2 | Jack the Ripper          | Crime    |     16.00 |");
            Console.WriteLine(" 3 | A Little Love Story      | Romance  |      2.40 |");
            Console.WriteLine(" 4 | Heresy                   | Fantasy  |      6.80 |");
            Console.WriteLine(" 5 | The Tolkien Years        | Fantasy  |     22.90 |");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Please place your order here: (Separate with comma or <space>)");
            Console.ReadLine();
        }
    }
}