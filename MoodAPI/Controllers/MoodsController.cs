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
using MoodAPI.Models;

namespace MoodAPI.Controllers
{
    public class MoodsController : ApiController
    {
        private IMoodContext db = new MoodContext();

        public MoodsController()
        {
        }

        public MoodsController(IMoodContext context)
        {
            db = context;
        }

        // GET: api/Moods
        public IQueryable<Mood> GetMoods()
        {
            return db.Moods;
        }

        // PUT: api/Moods/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMood(int id, Mood mood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mood.Id)
            {
                return BadRequest();
            }
                        
            db.MarkAsModified(mood);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoodExists(id))
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

        // POST: api/Moods
        [ResponseType(typeof(Mood))]
        public IHttpActionResult PostMood(Mood mood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Moods.Add(mood);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mood.Id }, mood);
        }

        // DELETE: api/Moods/5
        [ResponseType(typeof(Mood))]
        public IHttpActionResult DeleteMood(int id)
        {
            Mood mood = db.Moods.Find(id);
            if (mood == null)
            {
                return NotFound();
            }

            db.Moods.Remove(mood);
            db.SaveChanges();

            return Ok(mood);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool MoodExists(int id)
        {
            return db.Moods.Count(e => e.Id == id) > 0;
        }
    }
}