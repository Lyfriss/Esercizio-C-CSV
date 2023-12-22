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
        public Double UnitPrice { get; set; }

        [Name("Percentage discount")]
        public int PercenageDiscount { get; set; }

        [Name("Buyer")]
        public string Buyer {  get; set; }
        
        public string toString()
        {
            return "Id: " + Id +
                   ", Article name: " + ArticleName +
                   ", Quantiy: " + Quantity +
                   ", Unit price: " + UnitPrice +
                   ", Percentage discount: " + PercenageDiscount +
                   ", Buyer: " + Buyer;
        }
        
        public Double GetTotalImport()
        {
            return UnitPrice * Quantity;
        }
        public Double GetTotalImportedDiscounted()
        {
            Double normaPrice = UnitPrice;
            Double discont = UnitPrice * PercenageDiscount / 100;
            Double discountedPrice = normaPrice - discont;
            return discountedPrice * Quantity;
        }
        
        public Double GetDiscountedDifference()
        {
            return UnitPrice * PercenageDiscount /100 *Quantity;
        }

    }
}
