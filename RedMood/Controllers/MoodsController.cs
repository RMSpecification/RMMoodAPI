﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RedMood.Models;
using System.Threading.Tasks;

namespace RedMood.Controllers
{
    public class MoodsController : Controller
    {
        private RedMoodContext db = new RedMoodContext();
        private MoodService service = new MoodService();

        // GET: Moods/Increase/5
        public async Task<ActionResult> Increase(int id)
        {
            await service.Increase(id);
            return await Index();
        }

        // GET: Moods         
        public async Task<ActionResult> Index()
        {
            db.Moods = await service.GetMoodsAsync();
            return View("index",
                db.Moods
            );
        }
    }
}
