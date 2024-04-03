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
        [Shirt_ValidateShirtFilter]
        public IActionResult GetShirtsbyId(int id)
        {
            return Ok(ShirtRepository.GetShirtsbyId(id));
        }


        // [HttpGet("route/{id}/{color}")]
        // public string GetShirtsRoute(int id, [FromRoute] string color) // model binding
        // {
        //     return $"Reading the shirt with id: {id} \n with color: {color}";
        // }

        [HttpPost("body")]
        public IActionResult CreateShirtsbody([FromBody]Shirt shirt) //put brakepoint for test
        {
             if (shirt == null) return BadRequest();

             var existingShirt = ShirtRepository.GetShirtByProperties(shirt.Brand, shirt.Gender, shirt.Color, shirt.Size);
             if (existingShirt != null) return BadRequest();

             ShirtRepository.AddShirt(shirt);


            return CreatedAtAction(nameof(GetShirtsbyId),
                new { id = shirt.ShirtId}, shirt);
        }

        [HttpPost("form")]
        public string CreateShirtsform([FromForm]Shirt shirt) //form is also in body
        {
            return $"Create a shirt: {shirt}";
        }

        [HttpPut("{id}")]
        public string UpdateShirts(int id)
        {
            return $"Update the shirt with id: {id}";
        }

        [HttpDelete("{id}")]
        public string DeleteShirts(int id)
        {
            return $"Delete the shirt with id: {id}";
        }
    }
}























