using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication3.Data;
using WebApplication3.DTOs.Stocks;
using WebApplication3.Interfaces;
using WebApplication3.Mappers;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly ApplicationDBContext _dbContext;
        private readonly IStockRepository _stockRepository;

        public StockController(ApplicationDBContext applicationDBContext, IStockRepository stockRepository) {

            _stockRepository = stockRepository; 
            _dbContext = applicationDBContext;



            
        }

            [HttpGet] //definnig a get method
        public async Task <IActionResult>  GetAll()
        {

            var stocks = await _stockRepository.GetAllAsync(); // invoke repo
            var result = stocks.Select(stocks=>stocks.ToStockDTO());
            
            return Ok(result); //200 

        }

        [HttpGet("{id}")]  //ask for id in the url

        public async Task<IActionResult> GetStockById([FromRoute] int id)
        {
            try
            {
                var stock = await _stockRepository.GetStockAsync(id); // Filter based on the id provided

                if (stock == null)
                {
                    // If stock is not found, create a ResponseModel for the NotFound response
                    ResponseModel model = new ResponseModel
                    {
                        Message = $"Stock with id {id} not found",
                        StatusCode = 404,
                        Data = null // You can optionally set data to null or include additional information
                    };

                    // Return a NotFound response with the ResponseModel
                    return StatusCode(StatusCodes.Status404NotFound, model);
                }

                
                return Ok(stock.ToStockDTO()); 
            }
            catch (Exception ex)
            {
                
                ResponseModel rm = new ResponseModel
                {
                    Message = ex.ToString(),
                    StatusCode = 500,
                    Data = new { tokenNo = "" }
                };

                // Return an InternalServerError response with the ResponseModel
                return StatusCode(StatusCodes.Status500InternalServerError, rm);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostStockDTO postStockDTO)
        {
            var dto = postStockDTO.ToPostStockDTO();
            await _stockRepository.CreateStockAsync(dto);


            return CreatedAtAction(nameof(GetStockById), new { id = dto.StockId }, dto.ToStockDTO() );  // after successfully creating a dto object invoke the get by id method and return the data



        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDTO updateStockDTO)
        {
            //first find if object exists

            var stockModel = await _stockRepository.UpdateStockAsync(id, updateStockDTO);

            if (stockModel == null)
            {
                return NotFound();
            }



            return Ok(stockModel.ToStockDTO());

        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            //first check if object exists

            var stock = await _stockRepository.DeleteStockAsync(id);

            if(stock == null)
            {
                return NotFound();
            }

            

            return Ok();






        }
    
    
    }


    
}
