using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cv_8_backed.Models {
   public class Product {
      public int Id { get; set; }
      public string Name { get; set; }

      private ICollection<PriceHistoryEntry> priceHistory;
      public virtual ICollection<PriceHistoryEntry> PriceHistory {
         get {
            return priceHistory ?? (priceHistory = new HashSet<PriceHistoryEntry>());
         }
         set {
            priceHistory = value;
         }
      }

      private ICollection<PurchaseHistoryEntry> purchaseHistory;
      public virtual ICollection<PurchaseHistoryEntry> PurchaseHistory {
         get {
            return purchaseHistory ?? (purchaseHistory = new HashSet<PurchaseHistoryEntry>());
         }
         set {
            purchaseHistory = value;
         }
      }
   }
}