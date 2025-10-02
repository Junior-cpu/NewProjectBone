using Bonepile_New.Data;
using Bonepile_New.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bonepile_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetChartController : ControllerBase
    {

        private readonly BancoContext _context;
        public GetChartController(BancoContext context)
        {
            _context = context;   
        }


        [HttpGet]
        public async Task<IActionResult> GetCharts()
        {
            var chart = _context.UDTLOOK_UP_BONE_GERAL_HISTORICO_CHART.ToList();

            var result = from c in chart

                         group c by c.Customer into teste

                         select new
                         {
                             Customer = teste.Key,
                             Id = teste.Count()
                         };
            return Ok(result);
        }
    }
}
