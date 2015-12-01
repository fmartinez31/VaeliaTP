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
    public class ClassesWebAPIController : ApiController
    {
        private TPDataBaseEntities db = new TPDataBaseEntities();

        // A RAJOUTER CAR NON GENERER : ProxyCreationEnabled = false sinon erreur d'appel JSON
        public ClassesWebAPIController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/ClassesWebAPI
        public IQueryable<Classes> GetClasses()
        {
            return db.Classes;
        }

        // GET: api/ClassesWebAPI/5
        [ResponseType(typeof(Classes))]
        public IHttpActionResult GetClasses(int id)
        {
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return NotFound();
            }

            return Ok(classes);
        }

        // PUT: api/ClassesWebAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClasses(int id, Classes classes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classes.Id)
            {
                return BadRequest();
            }

            db.Entry(classes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassesExists(id))
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

        // POST: api/ClassesWebAPI
        [ResponseType(typeof(Classes))]
        public IHttpActionResult PostClasses(Classes classes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Classes.Add(classes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = classes.Id }, classes);
        }

        // DELETE: api/ClassesWebAPI/5
        [ResponseType(typeof(Classes))]
        public IHttpActionResult DeleteClasses(int id)
        {
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return NotFound();
            }

            db.Classes.Remove(classes);
            db.SaveChanges();

            return Ok(classes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassesExists(int id)
        {
            return db.Classes.Count(e => e.Id == id) > 0;
        }
    }
}