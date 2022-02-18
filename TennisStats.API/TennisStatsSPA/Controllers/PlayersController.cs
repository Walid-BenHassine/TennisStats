using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TennisStats.API;
using TennisStats.API.Models;
using TennisStatsSPA.Models;

namespace TennisStatsSPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Player>> Get([FromQuery] PlayerGetModel form)
        {
            TennisStatsAPIClient tennisStatsApiClient = new TennisStatsAPIClient();
            return await tennisStatsApiClient.GetPlayers(search: form.Search, page: form.Page);
        }
    }
}
