using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Contracts;
namespace ToysAPI​.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToysController : ControllerBase
    {
        private readonly IToyService _toyService;
        public ToysController(IToyService service)
        {
            _toyService = service;
        }

        [HttpGet]
        [Route("Get")]
        //TODO: Lets test with an exception inside GetToys :D 
        //TODO: Controllers should never return models
        public async Task<ActionResult<IEnumerable<ToysModel>>> GetToys() =>
        Ok(await _toyService.GetToys());


        [HttpGet]
        [Route("Get/{id:int:min(0)}")]
        public async Task<IActionResult> GetToyById(int id)
        {
            //TODO: Refactor ternary operator to have 1 line of code instead of 2 
            //TODO: Controllers should never return models 
            //Control + K + S   // Surround With
            var Toy = await _toyService.GetToyById(id);

            return Toy == null ? NotFound("Toy not found") : Ok(Toy);
            
            //return StatusCode(404, "Toy not found");
            // NotFound("Toy not found") 
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddToy(ToysModel toy)
        {
            try
            {
                await _toyService.AddToy(toy);

                return Ok("Toy added succesfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        //TODO: The controllers should never return Models, Try using DTOs instead
        public async Task<IActionResult> UpdateToy(ToysModel toy)
        {
            try
            {
                if (await _toyService.UpdateToy(toy))
                {
                    return Ok("Toy updated succesfully");
                }
               return StatusCode(404, "Toy not found");
             }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int:min(0)}")]
        public async Task<IActionResult> DeleteToy(int? id)
        {

            try
            {
                //TODO: use a ternary operator 
                if (await _toyService.DeleteToy(id))
                {
                    return Ok("Toy deleted succesfully");
                }
                //TODO: Kudos.! This should be returning not found if it is an iD not found
                return NotFound("Toy not found");

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}

