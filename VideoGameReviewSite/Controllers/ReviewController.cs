using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameReviewSite.Data;
using VideoGameReviewSite.Models;

namespace VideoGameReviewSite.Controllers
{
    public class ReviewController : Controller
    {
        private readonly VideoGameContext _context;
        public ReviewController(VideoGameContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var list = _context.Publishers
                .Include(b => b.VideoGame)
                .ToList();
            return View(list);
        }
        public ActionResult Details(int Id)
        {
            var list = _context.Publishers
                .Where(b => b.Id == Id)
                .Include(b => b.VideoGame)
                .FirstOrDefault();
            return View(list);
        }
       
    }
}
