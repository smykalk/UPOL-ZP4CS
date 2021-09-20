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
    public class PriceHistoryEntriesController : ODataController
    {
        private EshopContext db = new EshopContext();

        // GET: odata/PriceHistoryEntries
        [EnableQuery]
        public IQueryable<PriceHistoryEntry> GetPriceHistoryEntries()
        {
            return db.PriceHistory;
        }

        // GET: odata/PriceHistoryEntries(5)
        [EnableQuery]
        public SingleResult<PriceHistoryEntry> GetPriceHistoryEntry([FromODataUri] int key)
        {
            return SingleResult.Create(db.PriceHistory.Where(priceHistoryEntry => priceHistoryEntry.Id == key));
        }

        // PUT: odata/PriceHistoryEntries(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<PriceHistoryEntry> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PriceHistoryEntry priceHistoryEntry = db.PriceHistory.Find(key);
            if (priceHistoryEntry == null)
            {
                return NotFound();
            }

            patch.Put(priceHistoryEntry);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceHistoryEntryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(priceHistoryEntry);
        }

        // POST: odata/PriceHistoryEntries
        public IHttpActionResult Post(PriceHistoryEntry priceHistoryEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PriceHistory.Add(priceHistoryEntry);
            db.SaveChanges();

            return Created(priceHistoryEntry);
        }

        // PATCH: odata/PriceHistoryEntries(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<PriceHistoryEntry> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PriceHistoryEntry priceHistoryEntry = db.PriceHistory.Find(key);
            if (priceHistoryEntry == null)
            {
                return NotFound();
            }

            patch.Patch(priceHistoryEntry);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceHistoryEntryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(priceHistoryEntry);
        }

        // DELETE: odata/PriceHistoryEntries(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            PriceHistoryEntry priceHistoryEntry = db.PriceHistory.Find(key);
            if (priceHistoryEntry == null)
            {
                return NotFound();
            }

            db.PriceHistory.Remove(priceHistoryEntry);
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

        private bool PriceHistoryEntryExists(int key)
        {
            return db.PriceHistory.Count(e => e.Id == key) > 0;
        }
    }
}
