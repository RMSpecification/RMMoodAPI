using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedMoodAPI.Models
{
    public interface IMoodRepository
    {
        IEnumerable<Mood> GetAll();
        bool Increase(int id);
        Mood Get(int id);
        Mood Add(Mood item);
        bool Update(Mood item);
    }
}