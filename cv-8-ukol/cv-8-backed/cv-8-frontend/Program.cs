using cv_8_backed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_8_frontend {
   class Program {
      static void Main(string[] args) {
         Container productsContainer = new Container(new Uri("https://localhost:44370/odata/"));


         var products = productsContainer.Products;

         foreach(var product in products) {
            Console.WriteLine(product.Id + " " + product.Name);
         }

      }
   }
}
