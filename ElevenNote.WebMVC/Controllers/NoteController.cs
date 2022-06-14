using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenNote.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElevenNote.WebMVC.Controllers
{

    [Authorize]

    public class NoteController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new NoteListItem[0];
            return View(model);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }
    }
}

