using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using StellerAPI.Manager;
using StellerAPI.StellerCore;
using StellerAPI.Models;
using System.Threading.Tasks;

namespace StellerAPI.Controllers
{
    [Route("api/[controller]")]
    public class EnvironmentsController: Controller
    {
        private readonly IEnvironmentManager _environmentManager;
        public EnvironmentsController(IEnvironmentManager environmentManager)
        {            
            _environmentManager = environmentManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _environmentManager.GetEnvironments());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string env) 
        {
            return Ok(await _environmentManager.CreateContainer());
        }
    }
}