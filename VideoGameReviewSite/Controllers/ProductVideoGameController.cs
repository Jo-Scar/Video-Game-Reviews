using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameReviewSite.Data;
using VideoGameReviewSite.Models;

namespace VideoGameReviewSite.Controllers
{
    public class ProductVideoGameController : Controller
    {
        private readonly VideoGameContext _context;
        public ProductVideoGameController(VideoGameContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.VideoGame
                .Include(p => p.Publishers).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductVideoGameModel productVideoGame)
        {
            if (ModelState.IsValid)
            {
                productVideoGame.PublishersId = GetPublisher
                    (productVideoGame.NewPublisher);
                _context.VideoGame.Add(productVideoGame);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productVideoGame);
        }
        public ActionResult Delete(int Id)
        {
            if(Id == 0)
            {
                return NotFound();
            }
            var game = _context.VideoGame
                .Where(g => g.Id == Id)
                .Include(g => g.Publishers)
                .FirstOrDefault(
                g => g.Id == Id);
            if(game == null)
            {
                return NotFound();
            }
            return View(game);
        }
        [HttpPost]
        public ActionResult Delete(int? id, bool notUsed)
        {
            if (_context.VideoGame == null)
            {
                return Problem("Entity set 'VideoGameContext.VideoGame is null");
            }
            var productVideoGame = _context.VideoGame.Find(id);
            _context.VideoGame.Remove(productVideoGame);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, ProductVideoGameModel productVideoGame)
        {
            if (ModelState.IsValid)
            {
                productVideoGame.PublishersId = GetPublisher(productVideoGame.NewPublisher);
                _context.Entry(productVideoGame).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productVideoGame);
        }
        public ActionResult Details(int Id)
        {
            if(Id == 0)
            {
                return NotFound();
            }
            var productVideoGame = _context.VideoGame
                .Where(b => b.Id == Id)
                .Include(b => b.Publishers)
                .FirstOrDefault();
            return View(productVideoGame);
        }
        private int GetPublisher(string publisher)
        {
            ReviewModel? pub = null;
            pub = _context.Publishers
                .Where(p => p.Name.ToLower() == publisher.ToLower())
                .FirstOrDefault();
            if(pub == null)
            {
                pub = new ReviewModel { Name = publisher };
                _context.Add(pub);
                _context.SaveChanges(true);
            }
            return pub.Id;
        }
    }
}
