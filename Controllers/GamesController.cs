using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EloGame.Data;
using EloGame.Models;


namespace EloGame.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            return View(await _context.Game.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create/leagueId
        public IActionResult Create(int? id)
        {

            ViewBag.id = id;
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,time,playerNum,leagueId")] Game game)
        {

            game.time = DateTime.Now.ToUniversalTime();
            if (ModelState.IsValid)
            {
                game.Id = 0;
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction("OrderPlayers", "Games", new { id = game.Id });
            }
            return View(game);
        }


        public IActionResult OrderPlayers(int gameId)
        {
            var game = _context.Game.Where( x=> x.Id == gameId).FirstOrDefault();
            if (game != null)
            {
                var leaguePos = _context.LeaguePos
                    .Where(x => x.leagueId == game.leagueId)
                    .ToList();
                var players = new List<Player>();
                foreach (var league in leaguePos)
                {
                    players.Add(_context.Player.Where(x => x.Id == league.playerId).First());//ineficient
                }
                ViewBag.Players = new SelectList(players, "Id", "Name");
                return View();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderPlayers(OrderPlayersViewModel model,int gameId)
        {
            var game = _context.Game.Where(x => x.Id == gameId).FirstOrDefault();
            var numPlayers = game.playerNum;
            var elos = new int[numPlayers];
            var newElos = new int[numPlayers];
            var leaguePosArr = new LeaguePos[numPlayers];
            for (int i = 0; i < model.players.Count; i++){
                var leaguePos = _context.LeaguePos.Where(x => x.playerId == model.players[i].Id && x.leagueId == game.leagueId).First();
                elos[i] = leaguePos.elo;
            }
            var denominator = numPlayers * (numPlayers - 1) / 2;
            var d = 1;
            var k = 10;
            var eValues = new int [numPlayers];
            var sValues = new int [numPlayers];
            var finalChange = new int[numPlayers];
            for  (int i = 0; i < model.players.Count -1; i++) { 

                var player1 = model.players[i];
                for (int j = i + 1; j < model.players.Count; i++)
                {
                    var player2 = model.players[j];

                    eValues[i] += 1 / (1 + d ^ ((elos[i] - elos[j]) / d));
                    eValues[j] += 1 / (1 + d ^ ((elos[j] - elos[i]) / d));
                }

            }

            for (int i = 0; i < numPlayers; i++)
            {
                eValues[i] = eValues[i] / denominator;
                sValues[i] = (numPlayers - i +1) / denominator;
                finalChange[i] = k * (sValues[i] - eValues[i]);
                newElos[i] = elos[i] +  finalChange[i];

                var leaguePos = leaguePosArr[i];
                leaguePos.elo = newElos[i];
                _context.Update(leaguePos);
                var performance = new Performance();
                performance.playerId = leaguePosArr[i].playerId;
                performance.startElo = elos[i];
                performance.endElo = newElos[i];
                performance.position = i + 1;
                performance.gameId = game.Id;

                _context.Add(performance);
                await _context.SaveChangesAsync();
            }

            return View(model);


        }


        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,time,playerNum")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
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
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Game.FindAsync(id);
            if (game != null)
            {
                _context.Game.Remove(game);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}
