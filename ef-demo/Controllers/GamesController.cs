using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ef_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameReviewContext db;

        public GamesController(GameReviewContext db)
        {
            this.db = db;
        }

        [HttpGet()]
        public async Task<List<Game>> GetAll()
        {
            return await db.Games
                .Include(g => g.Reviews)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Game> GetById(int id)
        {
            return await db.Games
                .FromSqlInterpolated($"select * from Games where Id = {id}")
                .SingleAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Game update)
        {
            var game = await db.Games.FindAsync(id);

            game.Description = update.Description;
            game.Name = update.Name;
            game.Etag = Guid.NewGuid();

            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(Game game)
        {
            db.Games.Add(game);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = db.Games
                .Where(game => game.Id == id);

            db.Games.RemoveRange(game);
            await db.SaveChangesAsync();

            return NoContent();
        }
    }
}
