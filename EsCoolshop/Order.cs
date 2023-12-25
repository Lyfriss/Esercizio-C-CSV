using CsvHelper.Configuration.Attributes;
namespace EsCoolshop
{
    internal class Order
    {
        //Id,Article Name,Quantity,Unit price,Percentage discount,Buyer
        [Name("Id")]
        public int Id { get; set; }

        [Name("Article Name")]
        public string ArticleName { get; set; }

        [Name("Quantity")]
        public int Quantity { get; set; }

        [Name("Unit price")]
        public double UnitPrice { get; set; }

        [Name("Percentage discount")]
        public int PercenageDiscount { get; set; }

        [Name("Buyer")]
        public string Buyer {  get; set; }
        
        public string ToString()
        {
            return "Id: " + Id +
                   ", Article name: " + ArticleName +
                   ", Quantiy: " + Quantity +
                   ", Unit price: " + UnitPrice +
                   ", Percentage discount: " + PercenageDiscount +
                   ", Buyer: " + Buyer;
        }
        
        public double GetTotalImport()
        {
            return UnitPrice * Quantity;
        }
        public double GetTotalImportedDiscounted()
        {
            double normaPrice = UnitPrice;
            double discont = UnitPrice * PercenageDiscount / 100;
            double discountedPrice = normaPrice - discont;
            return discountedPrice * Quantity;
        }

        public double GetDiscountedDifference()
        {
            return UnitPrice * PercenageDiscount /100 *Quantity;
        }

    }
}
