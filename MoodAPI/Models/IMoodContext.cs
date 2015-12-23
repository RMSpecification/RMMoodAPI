using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MoodAPI.Models
{
    public interface IMoodContext
    {
        DbSet<Mood> Moods { get; }
        int SaveChanges();
        void MarkAsModified(Mood item);
    }
}