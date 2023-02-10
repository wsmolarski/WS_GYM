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
              return View(await _context.Zajecia.ToListAsync());
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

        private bool ZajeciaExists(int id)
        {
          return _context.Zajecia.Any(e => e.Id == id);
        }
    }
}
