using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedMoodAPI.Models
{
    public class MoodRepository : IMoodRepository
    {
        private MoodContext db = new MoodContext();        

        public MoodRepository()
        {
        }

        public bool increase(int id)
        {
            Mood mood = Get(id);
            mood.count += 1;
            db.Entry(mood).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Mood> GetAll()
        {
            return db.Moods;
        }

        public Mood Get(int id)
        {
            return db.Moods.Find(id);
        }

        public Mood Add(Mood item)
        {
            db.Moods.Add(item);
            db.SaveChanges();
            return item;
        }

        public bool Update(Mood item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }
}