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
using Etudiant.Data;

namespace FinalMVC.Controllers
{
    public class EtudiantsWebAPIController : ApiController
    {
        private TPDataBaseEntities db = new TPDataBaseEntities();

        // A RAJOUTER CAR NON GENERER : ProxyCreationEnabled = false sinon erreur d'appel JSON
        public EtudiantsWebAPIController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/EtudiantsWebAPI
        public IQueryable<Etudiants> GetEtudiants()
        {
            return db.Etudiants;
        }

        // GET: api/EtudiantsWebAPI/5
        [ResponseType(typeof(Etudiants))]
        public IHttpActionResult GetEtudiants(int id)
        {
            Etudiants etudiants = db.Etudiants.Find(id);
            if (etudiants == null)
            {
                return NotFound();
            }

            return Ok(etudiants);
        }

        // PUT: api/EtudiantsWebAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEtudiants(int id, Etudiants etudiants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != etudiants.Id)
            {
                return BadRequest();
            }

            db.Entry(etudiants).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantsExists(id))
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

        // POST: api/EtudiantsWebAPI
        [ResponseType(typeof(Etudiants))]
        public IHttpActionResult PostEtudiants(Etudiants etudiants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Etudiants.Add(etudiants);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = etudiants.Id }, etudiants);
        }

        // DELETE: api/EtudiantsWebAPI/5
        [ResponseType(typeof(Etudiants))]
        public IHttpActionResult DeleteEtudiants(int id)
        {
            Etudiants etudiants = db.Etudiants.Find(id);
            if (etudiants == null)
            {
                return NotFound();
            }

            db.Etudiants.Remove(etudiants);
            db.SaveChanges();

            return Ok(etudiants);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EtudiantsExists(int id)
        {
            return db.Etudiants.Count(e => e.Id == id) > 0;
        }
    }
}