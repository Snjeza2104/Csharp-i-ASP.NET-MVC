using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIFakultet.Models;

namespace WebAPIFakultet.Controllers
{
    public class KolegijsController : ApiController
    {
        private dbFakultetEntities db = new dbFakultetEntities();

        // GET: api/Kolegijs
        public IQueryable<Kolegij> GetKolegij()
        {
            return db.Kolegij;
        }

        // GET: api/Kolegijs/5
        [ResponseType(typeof(Kolegij))]
        public IHttpActionResult GetKolegij(int id)
        {
            Kolegij kolegij = db.Kolegij.Find(id);
            if (kolegij == null)
            {
                return NotFound();
            }

            return Ok(kolegij);
        }

        // PUT: api/Kolegijs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKolegij(int id, Kolegij kolegij)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kolegij.id)
            {
                return BadRequest();
            }

            db.Entry(kolegij).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KolegijExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Kolegijs
        [ResponseType(typeof(Kolegij))]
        public IHttpActionResult PostKolegij(Kolegij kolegij)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kolegij.Add(kolegij);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kolegij.id }, kolegij);
        }

        // DELETE: api/Kolegijs/5
        [ResponseType(typeof(Kolegij))]
        public IHttpActionResult DeleteKolegij(int id)
        {
            Kolegij kolegij = db.Kolegij.Find(id);
            if (kolegij == null)
            {
                return NotFound();
            }

            db.Kolegij.Remove(kolegij);
            db.SaveChanges();

            return Ok(kolegij);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KolegijExists(int id)
        {
            return db.Kolegij.Count(e => e.id == id) > 0;
        }
    }
}