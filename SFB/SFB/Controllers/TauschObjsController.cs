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
using SFB.Models;

namespace SFB.Controllers
{
    /*
    Die Klasse "WebApiConfig" erfordert ggf. weitere Änderungen zum Hinzufügen einer Route für diesen Controller. Führen Sie diese Anweisungen in der Methode "Register" der Klasse "WebApiConfig" ordnungsgemäß zusammen. Beachten Sie, dass für OData-URLs zwischen Groß- und Kleinschreibung unterschieden wird.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using SFB.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<TauschObj>("TauschObjs");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class TauschObjsController : ODataController
    {
        private SFBContext db = new SFBContext();

        // GET: odata/TauschObjs
        [EnableQuery]
        public IQueryable<TauschObj> GetTauschObjs()
        {
            return db.TauschObjs;
        }

        // GET: odata/TauschObjs(5)
        [EnableQuery]
        public SingleResult<TauschObj> GetTauschObj([FromODataUri] int key)
        {
            return SingleResult.Create(db.TauschObjs.Where(tauschObj => tauschObj.ID == key));
        }

        // PUT: odata/TauschObjs(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<TauschObj> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TauschObj tauschObj = db.TauschObjs.Find(key);
            if (tauschObj == null)
            {
                return NotFound();
            }

            patch.Put(tauschObj);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TauschObjExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tauschObj);
        }

        // POST: odata/TauschObjs
        public IHttpActionResult Post(TauschObj tauschObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TauschObjs.Add(tauschObj);
            db.SaveChanges();

            return Created(tauschObj);
        }

        // PATCH: odata/TauschObjs(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<TauschObj> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TauschObj tauschObj = db.TauschObjs.Find(key);
            if (tauschObj == null)
            {
                return NotFound();
            }

            patch.Patch(tauschObj);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TauschObjExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tauschObj);
        }

        // DELETE: odata/TauschObjs(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            TauschObj tauschObj = db.TauschObjs.Find(key);
            if (tauschObj == null)
            {
                return NotFound();
            }

            db.TauschObjs.Remove(tauschObj);
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

        private bool TauschObjExists(int key)
        {
            return db.TauschObjs.Count(e => e.ID == key) > 0;
        }
    }
}
