using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace EsCoolshop
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //creo un vettore contenente tutti i records cosi mi sarà più facile lavorarci sopra
            Order[] orders;
            //gestisco la configurazione per quando prendo i records dal file
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { 
                HasHeaderRecord = true, //il primo record contiene i nomi delle colonne 
            };

            // chiedere in input dove si trova il file
            Console.WriteLine("dove si trova il file CSV ? ");
            string filePath = @"" + Console.ReadLine();
            string fileCSV = filePath;
            using (var reader = new StreamReader(fileCSV))

            using (var csv = new CsvReader(reader, config))
                orders = csv.GetRecords<Order>().ToArray();

            Console.WriteLine("Ordini: \n");

            for (int c  = 0; c < orders.Length; c++) { 
                {
                    Console.WriteLine(orders[c].toString());
                }
                
            }
            //records richiesti : 
            Order highestImportRecor = orders[0];
            Order highestQuantityOrder = orders[0];
            Order highestDifference = orders[0];
            for (int i =1; i < orders.Length; i++)
            {
                //record con la importo totale più alto:
                if (orders[i].GetTotalImport() > highestImportRecor.GetTotalImport())
                {
                    highestImportRecor = orders[i];
                }
                //record con la quantità più alta
                if (orders[i].Quantity > highestQuantityOrder.Quantity)
                {
                    highestQuantityOrder = orders[i];
                }
                //record con maggior differenza tra totale senza sconto e totale con sconto
                if (orders[i].GetDiscountedDifference() > highestDifference.GetDiscountedDifference())
                {
                    highestDifference = orders[i];
                }
            }
            Console.WriteLine("\nIl record con importo totale più alto:");
            Console.WriteLine(highestImportRecor.toString());
            Console.WriteLine("\nIl record con la quantità più alta:");
            Console.WriteLine(highestQuantityOrder.toString());
            Console.WriteLine("\nIl record con la differenza più grande tra inporto totale e importo scontato");
            Console.WriteLine(highestDifference.toString());


        }
    }
}
