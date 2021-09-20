using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using cv_8_backed.Models;

namespace cv_8_backed.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using cv_8_backed.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<PurchaseHistoryEntry>("PurchaseHistoryEntries");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PurchaseHistoryEntriesController : ODataController
    {
        private EshopContext db = new EshopContext();

        // GET: odata/PurchaseHistoryEntries
        [EnableQuery]
        public IQueryable<PurchaseHistoryEntry> GetPurchaseHistoryEntries()
        {
            return db.PurchaseHistory;
        }

        // GET: odata/PurchaseHistoryEntries(5)
        [EnableQuery]
        public SingleResult<PurchaseHistoryEntry> GetPurchaseHistoryEntry([FromODataUri] int key)
        {
            return SingleResult.Create(db.PurchaseHistory.Where(purchaseHistoryEntry => purchaseHistoryEntry.Id == key));
        }

        // PUT: odata/PurchaseHistoryEntries(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<PurchaseHistoryEntry> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PurchaseHistoryEntry purchaseHistoryEntry = db.PurchaseHistory.Find(key);
            if (purchaseHistoryEntry == null)
            {
                return NotFound();
            }

            patch.Put(purchaseHistoryEntry);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseHistoryEntryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(purchaseHistoryEntry);
        }

        // POST: odata/PurchaseHistoryEntries
        public IHttpActionResult Post(PurchaseHistoryEntry purchaseHistoryEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PurchaseHistory.Add(purchaseHistoryEntry);
            db.SaveChanges();

            return Created(purchaseHistoryEntry);
        }

        // PATCH: odata/PurchaseHistoryEntries(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<PurchaseHistoryEntry> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PurchaseHistoryEntry purchaseHistoryEntry = db.PurchaseHistory.Find(key);
            if (purchaseHistoryEntry == null)
            {
                return NotFound();
            }

            patch.Patch(purchaseHistoryEntry);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseHistoryEntryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(purchaseHistoryEntry);
        }

        // DELETE: odata/PurchaseHistoryEntries(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            PurchaseHistoryEntry purchaseHistoryEntry = db.PurchaseHistory.Find(key);
            if (purchaseHistoryEntry == null)
            {
                return NotFound();
            }

            db.PurchaseHistory.Remove(purchaseHistoryEntry);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PurchaseHistoryEntryExists(int key)
        {
            return db.PurchaseHistory.Count(e => e.Id == key) > 0;
        }
    }
}
