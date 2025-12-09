
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMonitoring.Application.Services.Queries.GetStock;

namespace StockMonitoring.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StockController(ISender sender): ControllerBase
    {
        
        [HttpGet("stock/all")]
        public async Task<IActionResult> GetAllStocks([FromQuery]int page,[FromQuery]int size=10)
        {
            var request = new GetStockQuery(page, size);
            var result = await sender.Send(request);    
            return Ok(result);
        }
    }
}
