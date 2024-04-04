using FirstWebApi.Filters;
using FirstWebApi.Models;
using FirstWebApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtController_2:ControllerBase
    {       
        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok(ShirtRepository.GetShirts());
        }

        // [HttpGet("{id}")]
        // public Shirt GetShirtsbyID(int id)
        // {
        //     var shirt =shirts.First(x => x.ShirtId == id);
        // }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtsbyId(int id)
        {
            return Ok(ShirtRepository.GetShirtsbyId(id));
        }

        [HttpPost("body")]
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirtsbody([FromBody]Shirt shirt) //put brakepoint for test
        {
            ShirtRepository.AddShirt(shirt);
            
            return CreatedAtAction(nameof(GetShirtsbyId),
                new { id = shirt.ShirtId}, 
                shirt);
        }

        [HttpPost("form")]
        public string CreateShirtsform([FromForm]Shirt shirt) //form is also in body
        {
            return $"Create a shirt: {shirt}";
        }

        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        public IActionResult UpdateShirts(int id,Shirt shirt)
        {
            try
            {
                ShirtRepository.UpdateShirt(shirt);
            }
            catch
            {
                if (!ShirtRepository.ShirtExists(id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public string DeleteShirts(int id)
        {
            return $"Delete the shirt with id: {id}";
        }
    }
}























