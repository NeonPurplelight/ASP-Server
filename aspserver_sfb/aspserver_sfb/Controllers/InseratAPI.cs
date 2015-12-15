using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using aspserver_sfb.Models;

namespace aspserver_sfb.Controllers
{
    /*
    Die Klasse "WebApiConfig" erfordert ggf. weitere Änderungen zum Hinzufügen einer Route für diesen Controller. Führen Sie diese Anweisungen in der Methode "Register" der Klasse "WebApiConfig" ordnungsgemäß zusammen. Beachten Sie, dass für OData-URLs zwischen Groß- und Kleinschreibung unterschieden wird.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using aspserver_sfb.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Inserat>("InseratAPI");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class InseratAPI : ODataController
    {
        private InseratContext db = new InseratContext();

        // GET: odata/InseratAPI
        [EnableQuery]
        public IQueryable<Inserat> GetInseratAPI()
        {
            return db.Inserats;
        }

        // GET: odata/InseratAPI(5)
        [EnableQuery]
        public SingleResult<Inserat> GetInserat([FromODataUri] int key)
        {
            return SingleResult.Create(db.Inserats.Where(inserat => inserat.ID == key));
        }

        // PUT: odata/InseratAPI(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Inserat> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Inserat inserat = await db.Inserats.FindAsync(key);
            if (inserat == null)
            {
                return NotFound();
            }

            patch.Put(inserat);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InseratExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(inserat);
        }

        // POST: odata/InseratAPI
        public async Task<IHttpActionResult> Post(Inserat inserat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inserats.Add(inserat);
            await db.SaveChangesAsync();

            return Created(inserat);
        }

        // PATCH: odata/InseratAPI(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Inserat> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Inserat inserat = await db.Inserats.FindAsync(key);
            if (inserat == null)
            {
                return NotFound();
            }

            patch.Patch(inserat);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InseratExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(inserat);
        }

        // DELETE: odata/InseratAPI(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Inserat inserat = await db.Inserats.FindAsync(key);
            if (inserat == null)
            {
                return NotFound();
            }

            db.Inserats.Remove(inserat);
            await db.SaveChangesAsync();

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

        private bool InseratExists(int key)
        {
            return db.Inserats.Count(e => e.ID == key) > 0;
        }
    }
}
