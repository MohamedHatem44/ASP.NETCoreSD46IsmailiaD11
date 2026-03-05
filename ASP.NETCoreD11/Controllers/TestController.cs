using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreD11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /*------------------------------------------------------------------*/
        [HttpGet]
        public string Get()
        {
            return "Hello From Test";
        }
        /*------------------------------------------------------------------*/
        //[HttpGet]
        //[Route("{id}")]
        [HttpGet("{id:int}")]
        public string GetById(int id)
        {
            return $"Get By Id, Id = {id}";
        }
        /*------------------------------------------------------------------*/
        //[HttpGet("/{name}")]
        //[HttpGet("/api/t/{name}")]
        [HttpGet("{name:alpha}")]
        public string GetById(string name)
        {
            return $"Get By Name, Name is {name}";
        }
        /*------------------------------------------------------------------*/
    }
}
