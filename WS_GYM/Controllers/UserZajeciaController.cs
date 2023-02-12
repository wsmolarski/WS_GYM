using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WS_GYM.Data;
using WS_GYM.Models;

namespace WS_GYM.Controllers
{
    [Authorize]
    public class UserZajeciaController : Controller
    {
        private readonly FitnessContext _context;

        public UserZajeciaController(FitnessContext context)
        {
            _context = context;
        }

        // GET: UserZajecia
        public async Task<IActionResult> Index()
        {
            List<Zajecia> zajecia = await _context.Zajecia.Include(i => i.ZajeciaUsers).ToListAsync();
            Karnet k = _context.Karnety.FirstOrDefault(f => f.UserId == User.GetId());

            foreach (var z in zajecia)
            {
                z.IsSigned = z.ZajeciaUsers.Any(a=>a.UserId == User.GetId());
            }

            if (k == null || !k.Active)
            {
                ViewData["msg"] = HttpContext.Session.GetString("msg");
            }

            return View(zajecia);
        }

        // GET: UserZajecia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zajecia == null)
            {
                return NotFound();
            }

            var zajecia = await _context.Zajecia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zajecia == null)
            {
                return NotFound();
            }

            return View(zajecia);
        }

        public async Task<IActionResult> SignUp(int? id)
        {
            Karnet k = _context.Karnety.FirstOrDefault(f => f.UserId == User.GetId());
            

            if (k == null || !k.Active)
            {
                HttpContext.Session.SetString("msg", "Brak aktywnego karnetu.");
                return RedirectToAction(nameof(Index));

            }

            if (id.HasValue && !_context.ZajeciaUser.Any(a => a.ZajeciaId == id && a.UserId == User.GetId()))
            {
                ZajeciaUser zajeciaUser = new ZajeciaUser();
                zajeciaUser.ZajeciaId = id.GetValueOrDefault();
                zajeciaUser.UserId = User.GetId();
                zajeciaUser.Zajecia = await _context.Zajecia.FindAsync(id);

                _context.ZajeciaUser.Add(zajeciaUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SignOut(int? id)
        {
            if (id.HasValue && _context.ZajeciaUser.Any(a => a.ZajeciaId == id && a.UserId == User.GetId()))
            {
                var z = _context.ZajeciaUser.First(f => f.ZajeciaId == id && f.UserId == User.GetId());
                _context.Remove(z);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ZajeciaExists(int id)
        {
          return _context.Zajecia.Any(e => e.Id == id);
        }
    }
}
