using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WS_GYM.Data;
using WS_GYM.Models;

namespace WS_GYM.Controllers
{
    [Authorize]
    public class UserKarnetyController : Controller
    {
        private readonly FitnessContext _context;

        public UserKarnetyController(FitnessContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            Karnet karnet = _context.Karnety.FirstOrDefault(f => f.UserId == User.GetId());
            return View(karnet);
        }

        public IActionResult BuyKarnet()
        {
            Karnet karnet = _context.Karnety.FirstOrDefault(f => f.UserId == User.GetId());

            if (karnet == null)
            {
                karnet = new Karnet() { Start = DateTime.Now, End = DateTime.Now.AddDays(30), UserId = User.GetId() };
                _context.Karnety.Add(karnet);
                _context.SaveChanges();
            }

            return Redirect("Index");
            }
        public IActionResult ExtendKarnet()
        {
            Karnet karnet = _context.Karnety.FirstOrDefault(f => f.UserId == User.GetId());

            if (karnet != null)
            {
                karnet.Start = DateTime.Now;
                karnet.End = DateTime.Now.AddDays(30);
                _context.SaveChanges();
            }

            return Redirect("Index");
        }
    }
}
