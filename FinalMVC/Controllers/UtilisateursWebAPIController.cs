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
    public class UtilisateursWebAPIController : ApiController
    {
        private TPDataBaseEntities db = new TPDataBaseEntities();

        // A RAJOUTER CAR NON GENERER : ProxyCreationEnabled = false sinon erreur d'appel JSON
        public UtilisateursWebAPIController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/UtilisateursWebAPI
        public IQueryable<Utilisateurs> GetUtilisateurs()
        {
            return db.Utilisateurs;
        }

        // GET: api/UtilisateursWebAPI/5
        [ResponseType(typeof(Utilisateurs))]
        public IHttpActionResult GetUtilisateurs(int id)
        {
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            if (utilisateurs == null)
            {
                return NotFound();
            }

            return Ok(utilisateurs);
        }

        // PUT: api/UtilisateursWebAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUtilisateurs(int id, Utilisateurs utilisateurs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != utilisateurs.Id)
            {
                return BadRequest();
            }

            db.Entry(utilisateurs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilisateursExists(id))
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

        // POST: api/UtilisateursWebAPI
        [ResponseType(typeof(Utilisateurs))]
        public IHttpActionResult PostUtilisateurs(Utilisateurs utilisateurs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Utilisateurs.Add(utilisateurs);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = utilisateurs.Id }, utilisateurs);
        }

        // DELETE: api/UtilisateursWebAPI/5
        [ResponseType(typeof(Utilisateurs))]
        public IHttpActionResult DeleteUtilisateurs(int id)
        {
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            if (utilisateurs == null)
            {
                return NotFound();
            }

            db.Utilisateurs.Remove(utilisateurs);
            db.SaveChanges();

            return Ok(utilisateurs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UtilisateursExists(int id)
        {
            return db.Utilisateurs.Count(e => e.Id == id) > 0;
        }
    }
}