using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EloGame.Data;
using EloGame.Models;

namespace EloGame.Controllers
{
    public class LeaguePosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaguePosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaguePos
        public async Task<IActionResult> Index()
        {
            return View(await _context.LeaguePos.ToListAsync());
        }

        // GET: LeaguePos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaguePos = await _context.LeaguePos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaguePos == null)
            {
                return NotFound();
            }

            return View(leaguePos);
        }

        // GET: LeaguePos/Create
        public IActionResult Create()
        {
            ViewBag.playerId = new SelectList(_context.Player, "Id","Name" );
            ViewBag.leagueId = new SelectList(_context.League, "Id", "Name");
            return View();
        }

        // POST: LeaguePos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] LeaguePos leaguePos)
        {

            if (leaguePos.leagueId == 0)
                ModelState.AddModelError("leagueId", "Please select a league");

            if (leaguePos.playerId == 0)
                ModelState.AddModelError("playerId", "Please select a player");

            leaguePos.elo = 1200;//or league default

            if (ModelState.IsValid)
            {
                _context.Add(leaguePos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.playerId = new SelectList(_context.Player, "Id", "Name");
            ViewBag.leagueId = new SelectList(_context.League, "Id", "Name");
            return View(leaguePos);
        }

        // GET: LeaguePos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaguePos = await _context.LeaguePos.FindAsync(id);
            if (leaguePos == null)
            {
                return NotFound();
            }
            return View(leaguePos);
        }

        // POST: LeaguePos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] LeaguePos leaguePos)
        {
            if (id != leaguePos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaguePos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaguePosExists(leaguePos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaguePos);
        }

        // GET: LeaguePos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaguePos = await _context.LeaguePos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaguePos == null)
            {
                return NotFound();
            }

            return View(leaguePos);
        }

        // POST: LeaguePos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaguePos = await _context.LeaguePos.FindAsync(id);
            if (leaguePos != null)
            {
                _context.LeaguePos.Remove(leaguePos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaguePosExists(int id)
        {
            return _context.LeaguePos.Any(e => e.Id == id);
        }
    }
}
