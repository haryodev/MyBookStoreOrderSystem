using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using ConsoleApp1;
using BookStoreOrderSystem.Models;
using Moq;

namespace Tests
{
    public class BookStoreOrderSystemTests
    {
        private Order _order;

        private Mock<Order> _mockOrder;


        [SetUp]
        public void Setup()
        {
            _order = new Order();
            _mockOrder = new Mock<Order>();
        }

        [Test]
        public void OrderPrintHeader_ShouldPrintSuccessully()
        {
            // Arrange

            // Act
            _order.PrintHeader();
            
            // Assert
            Assert.Pass();
        }

        [Test]
        public void OrderPrintItem_ShouldPrintSuccessully()
        {
            // Arrange
            Book _book = new Book(){Qty=123, Title="My Title", Category="My Category", UnitPrice=34.56m};
            string expectedResult = String.Format("{0} x {1}\t{2:C}\r\n", _book.Qty, _book.Title, _book.UnitPrice);
            StringWriter consoleText = null;

            // Act
            using (consoleText = new StringWriter())
            {
                Console.SetOut(consoleText);
                _order.PrintItem(_book);
            }
            
            // Assert
            Assert.AreEqual(expectedResult, consoleText.ToString());
        }

        [Test]
        public void OrderPrintItemDiscount_ShouldPrintSuccessfully()
        {
            // Arrange
            Decimal discountedPrice = 12.34m;
            string expectedResult = String.Format("Discount 5% Off Crime\t-{0:C}\r\n", discountedPrice);
            StringWriter consoleText = null;

            // Act
            using (consoleText = new StringWriter())
            {
                Console.SetOut(consoleText);
                _order.PrintItemDiscount(discountedPrice);
            }
            
            // Assert
            Assert.AreEqual(expectedResult, consoleText.ToString());
        }

        [Test]
        public void OrderPrintTotalCost_ShouldPrintSuccessfully()
        {
            // Arrange
            _order.DiscountPrice=12.34m;
            _order.Tax=0.5m;
            _order.TotalPrice=1000m;
            string expectedResult = String.Format("\r\n");
            expectedResult += String.Format("Sub Total\t\t{0:C}\r\n", _order.TotalPrice);
            expectedResult += String.Format("Tax\t\t\t{0:C}\r\n", _order.Tax * _order.TotalPrice);
            expectedResult += String.Format("TOTAL\t\t\t{0:C}\r\n", ((1m+_order.Tax) * _order.TotalPrice));
            StringWriter consoleText = null;

            // Act
            using (consoleText = new StringWriter())
            {
                Console.SetOut(consoleText);
                _order.PrintTotalCost();
            }
            
            // Assert
            Assert.AreEqual(expectedResult, consoleText.ToString());
            
        }

        [Test]
        public void OrderPrintOutput_ShouldCallAllFunctions()
        {
            // Arrange
            IList<Book> myOrder = new List<Book>() { 
                new Book(){ Qty=1, Category="Crime", Title="Unsolved Crimes", UnitPrice=10.99m},
                new Book(){ Qty=1, Category="Romance", Title="A Little Love Story", UnitPrice=2.40m},
            };
            StringWriter consoleText = null;
            //_mockOrder.Setup(d => d.PrintOutput(It.IsAny<IList<Book>>()));

            // Act
            using (consoleText = new StringWriter())
            {
                Console.SetOut(consoleText);
                _order.PrintOutput(myOrder);
            }

            // Assert
            Assert.Pass("Test Successful");

            // _mockOrder.Verify(
            //     x => x.PrintHeader(),
            //     Times.Never());

        }

        [Test]
        public void OrderPrintOrders_ShouldCalculateTotalPriceCorrectly()
        {
            // Arrange
            IList<Book> myOrder = new List<Book>() { 
                new Book(){ Qty=1, Category="Crime", Title="Unsolved Crimes", UnitPrice=10.99m},
                new Book(){ Qty=1, Category="Romance", Title="A Little Love Story", UnitPrice=2.40m},
            };
            StringWriter consoleText = null;
            Decimal expectedTotalPrice = 10.99m + 2.40m - (_order.DiscountPrice * 10.99m);

            // Act
            using (consoleText = new StringWriter())
            {
                Console.SetOut(consoleText);
                _order.PrintOrders(myOrder);
            }

            // Assert
            Assert.AreEqual(expectedTotalPrice, _order.TotalPrice);
        }

        [Test]
        public void OrderPrintOrders_ShouldPrintOrdersCorrectly()
        {
            // Arrange
            IList<Book> myOrder = new List<Book>() { 
                new Book(){ Qty=1, Category="Crime", Title="Unsolved Crimes", UnitPrice=10.99m},
                new Book(){ Qty=1, Category="Romance", Title="A Little Love Story", UnitPrice=2.40m},
            };
            StringWriter consoleText = null;
            Decimal expectedTotalPrice = 10.99m + 2.40m - (_order.DiscountPrice * 10.99m);
            String expectedResult = String.Format("1 x Unsolved Crimes\t$10.99\r\n");
            expectedResult += String.Format("Discount 5% Off Crime\t-$0.55\r\n");
            expectedResult += String.Format("1 x A Little Love Story\t$2.40\r\n");

            // Act
            using (consoleText = new StringWriter())
            {
                Console.SetOut(consoleText);
                _order.PrintOrders(myOrder);
            }

            // Assert
            Assert.AreEqual(expectedResult, consoleText.ToString());
        }
    }
}