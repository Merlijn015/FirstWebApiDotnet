using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [ApiController]
    public class ShirtController:ControllerBase
    {
        [HttpGet]
        [Route("/shirts")]
        public string GetShirts()
        {
            return "Reading all the shirts";
        }

        [HttpGet]
        [Route("/shirts/{id}")]
        public string GetShirts(int id)
        {
            return "Reading the shirt with id: {id}";
        }

        [HttpPost]
        [Route("/shirts")]
        public string CreateShirts()
        {
            return "Create a shirt";
        }

        [HttpPut]
        [Route("/shirts/{id}")]
        public string UpdateShirts(int id)
        {
            return "Update the shirt with id: {id}";
        }

        [HttpDelete]
        [Route("/shirts/{id}")]
        public string DeleteShirts(int id)
        {
            return "Delete the shirt with id: {id}";
        }
    }
}