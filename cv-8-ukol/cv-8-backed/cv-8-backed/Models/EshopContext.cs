using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace cv_8_backed.Models {
   public class EshopContext : DbContext {
      public EshopContext() : base("EshopConnection") {
      }

      public DbSet<Product> Products { get; set; }
      public DbSet<PurchaseHistoryEntry> PurchaseHistory { get; set; }
      public DbSet<PriceHistoryEntry> PriceHistory { get; set; }
   }
}