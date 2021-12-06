using Microsoft.AspNetCore.Mvc;
using StockManagement_Lib;

namespace Stock_Management_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CricketScoresController : ControllerBase
    {

        private static readonly int[] Runs = new[]
        {
            224, 221, 196, 122, 35
        };

        private readonly ILogger<CricketScoresController> _logger;

        public CricketScoresController(ILogger<CricketScoresController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCricketScores")]
        public IEnumerable<CricketScore> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new CricketScore
            {
                Date = DateTime.Now.AddDays(index),
                Overs = Random.Shared.Next(35, 50),
                Wickets = Random.Shared.Next(0, 10),
                Hours = Random.Shared.Next(4, 6),
                Score = Runs[Random.Shared.Next(Runs.Length)]

            })
            .ToArray();
        }
    }
}
