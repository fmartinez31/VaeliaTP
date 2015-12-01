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
    public class ProfesseursWebAPIController : ApiController
    {
        private TPDataBaseEntities db = new TPDataBaseEntities();

        // A RAJOUTER CAR NON GENERER : ProxyCreationEnabled = false sinon erreur d'appel JSON
        public ProfesseursWebAPIController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/ProfesseursWebAPI
        public IQueryable<Professeurs> GetProfesseurs()
        {
            return db.Professeurs;
        }

        // GET: api/ProfesseursWebAPI/5
        [ResponseType(typeof(Professeurs))]
        public IHttpActionResult GetProfesseurs(int id)
        {
            Professeurs professeurs = db.Professeurs.Find(id);
            if (professeurs == null)
            {
                return NotFound();
            }

            return Ok(professeurs);
        }

        // PUT: api/ProfesseursWebAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfesseurs(int id, Professeurs professeurs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != professeurs.Id)
            {
                return BadRequest();
            }

            db.Entry(professeurs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesseursExists(id))
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

        // POST: api/ProfesseursWebAPI
        [ResponseType(typeof(Professeurs))]
        public IHttpActionResult PostProfesseurs(Professeurs professeurs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Professeurs.Add(professeurs);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = professeurs.Id }, professeurs);
        }

        // DELETE: api/ProfesseursWebAPI/5
        [ResponseType(typeof(Professeurs))]
        public IHttpActionResult DeleteProfesseurs(int id)
        {
            Professeurs professeurs = db.Professeurs.Find(id);
            if (professeurs == null)
            {
                return NotFound();
            }

            db.Professeurs.Remove(professeurs);
            db.SaveChanges();

            return Ok(professeurs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfesseursExists(int id)
        {
            return db.Professeurs.Count(e => e.Id == id) > 0;
        }
    }
}