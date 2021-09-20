using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cv_8_backed.Models {
   public class PriceHistoryEntry {
      public int Id { get; set; }
      public virtual int ProductId { get; set; }
      public DateTime Date { get; set; }
      public decimal Price { get; set; }
   }
}