using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OGptWebApiApplication.Model;
using OGptWebApiApplication.Services;
using System.Text.Json;

namespace OGptWebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ImagesServices ımagesServices;

        public ImagesController(ImagesServices _ımagesServices)
        {
            this.ımagesServices = _ımagesServices;
        }

        [HttpPost]
        public async Task<IActionResult> Images([FromBody] Images ımages)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Boş bir değer girdiniz.");
                return BadRequest();

            }
             List<string>urlList= await ımagesServices.startRequest(ımages);
           
            return Ok(urlList);
        }
    }
}
