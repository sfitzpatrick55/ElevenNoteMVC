using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ElevenNote.Data;
using ElevenNote.Models.Note;
using ElevenNote.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElevenNote.WebMVC.Controllers
{

    [Authorize]

    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _ctx;

        public NoteController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        // GET: /<controller>/
        public ActionResult Index()
        {
            var service = CreateNoteService();

            var model = service.GetNotes();

            return View(model);
        }

        public NoteService CreateNoteService()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = Guid.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var userId = SignInManager.AuthenticationManager.AuthenticationResponseGrant.Identity.GetUserId();
            var service = new NoteService(currentUserID, _ctx);
            return service;
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateNoteService();

            service.CreateNote(model);

            return RedirectToAction("Index");
        }

        //private NoteService CreateNoteService()
        //{
        //    ClaimsPrincipal currentUser = this.User;
        //    var currentUserId = Guid.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
        //    //var userId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new NoteService(currentUserId, _ctx);
        //    return service;
        //}
    }
}