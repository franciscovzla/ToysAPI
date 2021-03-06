using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Contracts;
using Services.DTO;
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

        public async Task<ActionResult> GetToys() =>
            Ok(await _toyService.GetToys());


        [HttpGet]
        [Route("Get/{id:int:min(0)}")]
        public async Task<IActionResult> GetToyById(int id)
        {

            var Toy = await _toyService.GetToyById(id);

            return Toy is null ? NotFound("Toy not found") : Ok(Toy);

        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddToy(ToysDTO toy)
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
       
        public async Task<IActionResult> UpdateToy(ToysDTO toy)
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

                return await _toyService.DeleteToy(id) ? Ok("Toy deleted succesfully") : NotFound("Toy not found");

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}

