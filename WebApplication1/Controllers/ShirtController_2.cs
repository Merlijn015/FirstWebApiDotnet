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
        public IActionResult GetShirtsbyID(int id)
        {
            return Ok(ShirtRepository.GetShirtsbyID(id));
        }


        // [HttpGet("route/{id}/{color}")]
        // public string GetShirtsRoute(int id, [FromRoute] string color) // model binding
        // {
        //     return $"Reading the shirt with id: {id} \n with color: {color}";
        // }

        [HttpPost("body")]
        public string CreateShirtsbody([FromBody]Shirt shirt) //put brakepoint for test
        {
            return $"Create a shirt: {shirt}";
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























