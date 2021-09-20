using cv_8_backed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_8_frontend {
   class Program {
      static void Main(string[] args) {
         Container c = new Container(new Uri("https://localhost:44370/odata/"));

         Console.Write("Search for products containing: ");
         string filter = Console.ReadLine();

         var prods = c.Products.Where(p => p.Name.Contains(filter));

         foreach (var prod in prods) {
            Console.WriteLine($"ID: {prod.Id}, Name: {prod.Name}");
            var priceHist = c.PriceHistoryEntries.Where(e => e.ProductId == prod.Id).OrderBy(e => e.Date);
            var purchaseHist = c.PurchaseHistoryEntries.Where(e => e.ProductId == prod.Id).OrderBy(e => e.Date);
            
            Console.WriteLine("Price history:");
            foreach (var e in priceHist) {
               Console.WriteLine(e.Date.ToShortDateString() + " " + e.Price);
            }

            Console.WriteLine("\nPurchase history:");
            foreach(var e in purchaseHist) {
               Console.WriteLine(e.Date.ToShortDateString() + " " + e.CustomerName);
            }

            Console.WriteLine("--------------------------------------------");
         }

         Console.ReadLine();
      }
   }
}
