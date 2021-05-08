using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WebJdr.Models;
using WebJdr.DAL;

namespace WebJdr.Controllers
{
    public class DashboardController : Controller
    {
        readonly DatabaseContext _context;

		public DashboardController(DatabaseContext context)
		{
            _context = context;
		}

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewGame()
        {
            return GameLoop(_context.Sequences.First());
        }

        public ActionResult SelectStory()
        {
            Save tempSave = new Save();
            return View(tempSave);
        }

        public IActionResult CreateCharacter(Save tempSave)
        {
            Console.WriteLine(tempSave.CurrentStory.Name);
            Console.WriteLine(Request.Form["number"]);
            return View();
        }

        [HttpGet]
        public IActionResult GameLoop(Sequence sequence)
		{
            return View(sequence);
		}
        [HttpPost]
        public IActionResult GameLoop(int nextSequenceId)
		{
            var nextSequence = _context.Sequences.ElementAtOrDefault(nextSequenceId);

            if (nextSequence != null)
                return View(nextSequence);
            else
                return RedirectToAction("Index");
		}
    }
}