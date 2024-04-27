using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebApplication3.Data;
using WebApplication3.Mappers;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly ApplicationDBContext _dbContext;

        public StockController(ApplicationDBContext applicationDBContext) {

            _dbContext = applicationDBContext;



            
        }

            [HttpGet] //definnig a get method
        public IActionResult GetAll()
        {

            var stocks = _dbContext.Stocks.ToList().Select(e=>e.ToStockDTO()); //select is simialr to dart map method 
            return Ok(stocks); //200 

        }

        [HttpGet("{id}")]  //ask for id in the url

public IActionResult GetStockById([FromRoute] int id)
        {


            var stock = _dbContext.Stocks.SingleOrDefault(e => e.StockId == id); //filter based on the id provided

            if(stock == null)
            {
                return NotFound(); //404 
            }

            return Ok(stock.ToStockDTO());  //200 

        }
    }
}
