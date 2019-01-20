using GigHub.Models;
using GigHub.ViewModel;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Attending()
        {
            var UserId = User.Identity.GetUserId();
            var gigs = _context.Attendances
                .Where(a => a.AttendeeId
                == UserId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Artist)
                .ToList();


            var model = new HomeViewModel
            {
                upComingGigs =gigs,
                ShowAction = User.Identity.IsAuthenticated,
            };
            return View(model);
        }
        // GET: Gigs
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.Genres = _context.Genres.ToList();
                return View("Create", model);

            }

            var gig = new Gig()
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = model.GetDateTime(),
                GenreId = model.Genre,
                Venue = model.Venue,
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}