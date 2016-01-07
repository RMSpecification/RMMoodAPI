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
        public IHttpActionResult PutMood(int id)
        {
            var mood = db.Moods.Find(id);
            if( mood == null )
            {
                return NotFound();
            }

            mood.Counter += 1;                     
            db.MarkAsModified(mood);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool MoodExists(int id)
        {
            return db.Moods.Count(e => e.Id == id) > 0;
        }
    }
}