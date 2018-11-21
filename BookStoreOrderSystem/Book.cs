namespace BookStoreOrderSystem.Models
{
    public class Book
    { 
        public int Qty { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public decimal UnitPrice { get; set; }

        public Book()
        {
        }

        public Book(int inQty, string inCategory, string inTitle, decimal inUnitPrice)
        {
            Qty = inQty;
            Category = inCategory;
            Title = inTitle;
            UnitPrice = inUnitPrice;
        }
    }
}