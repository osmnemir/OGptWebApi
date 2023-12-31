﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OGptWebApiApplication.Services;
using System.Text.Json;

namespace OGptWebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompletionController : ControllerBase
    {
        private readonly CompletionServices _completionServices;

        public CompletionController(CompletionServices completionServices)
        {
            _completionServices = completionServices;
        }

        [HttpPost]
        public async Task<IActionResult> Chat([FromBody] string prompt)
        {
            if(prompt==null)
            {
                throw new Exception("Boş bir değer girdiniz.");
                return BadRequest();

            }
            string cevap=await _completionServices.startRequest(prompt);
            var jsonCevap=JsonSerializer.Serialize(cevap);
            return Ok(jsonCevap);
        }
    }
}
