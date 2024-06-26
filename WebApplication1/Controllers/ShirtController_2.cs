using FirstWebApi.Filters.ExceptionFilters;
using FirstWebApi.Filters.ActionFilters;
using FirstWebApi.Models;
using FirstWebApi.Models.Repositories;
using FirstWebApi.Filters.AuthFilters;
using Microsoft.AspNetCore.Mvc;


namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [JwtTokenAuthFilter]
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
        [Shirt_HandleUpdateExeptionsFilter]
        public IActionResult UpdateShirts(int id,Shirt shirt)
        {
            ShirtRepository.UpdateShirt(shirt);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult DeleteShirts(int id)
        {
            var shirt = ShirtRepository.GetShirtsbyId(id);
            ShirtRepository.DeleteShirt(id);

            return Ok(shirt);
        }
    }
}























