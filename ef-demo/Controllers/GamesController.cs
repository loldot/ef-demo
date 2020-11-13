using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            return await db.Games.ToListAsync();
        }
    }
}
