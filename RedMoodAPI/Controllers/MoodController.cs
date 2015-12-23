using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RedMoodAPI.Models;

namespace RedMoodAPI.Controllers
{
    public class MoodController : ApiController
    {
        static IMoodRepository _repository;
        public MoodController(IMoodRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            _repository = repository;
        }
    }
}
