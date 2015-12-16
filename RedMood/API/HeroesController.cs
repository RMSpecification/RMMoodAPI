using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using RedMood.Models;

namespace RedMood.API
{
    [Route("api/[controller]")]
    public class HeroesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<DOTAHero> Get()
        {
            HeroManager HM = new HeroManager();
            return HM.GetAll;
        }

        // GET api/values/7
        [HttpGet("{id}")]
        public DOTAHero Get(int id)
        {
            HeroManager HM = new HeroManager();
            return HM.GetHeroByID(id);
        }

    }
}
