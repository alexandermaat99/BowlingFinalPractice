using BowlingFinalPractice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BowlingFinalPractice.Controllers
{
    public class HomeController : Controller
    {
        private IBowlingRepository _repo;

        public HomeController(IBowlingRepository temp)
        {
            _repo = temp;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Bowler());
        }

        [HttpPost]

        public IActionResult Index(Bowler b)
        {
            if(ModelState.IsValid)
            {
                _repo.AddBowler(b);
            }
            return View(new Bowler());
        }

        public IActionResult AllBowlersPage()
        {
            var bowlers = _repo.GetAllBowlers();
            return View(bowlers);
        }

        [HttpPost]
        public IActionResult EditBowler(Bowler bowler) 
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateBowler(bowler);
                return RedirectToAction("AllBowlersPage");
            }
            return View(bowler);
            
        }

        [HttpGet]
        public IActionResult EditBowler(int id)
        {
            Bowler bowler = _repo.GetBowlerByID(id);
            if (bowler == null)
            {
                return NotFound();
            }
            return View(bowler);
        }

    }
}
