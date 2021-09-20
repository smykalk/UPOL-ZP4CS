using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using cv_8_backed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace cv_8_backed {
   public static class WebApiConfig {
      public static void Register(HttpConfiguration config) {
         // Web API configuration and services

         // Web API routes
         config.MapHttpAttributeRoutes();

         config.Routes.MapHttpRoute(
             name: "DefaultApi",
             routeTemplate: "api/{controller}/{id}",
             defaults: new { id = RouteParameter.Optional }
         );

         ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
         builder.EntitySet<Product>("Products");
         //builder.EntitySet<PriceHistoryEntry>("PriceHistory");
         builder.EntitySet<PriceHistoryEntry>("PriceHistoryEntries");
         //builder.EntitySet<PurchaseHistoryEntry>("PurchaseHistory");
         builder.EntitySet<PurchaseHistoryEntry>("PurchaseHistoryEntries");

         config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
      }
   }
}
