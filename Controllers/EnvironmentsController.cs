using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using StellerAPI.Manager;
using StellerAPI.StellerCore;
using StellerAPI.Models;

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
        public IMongoCollection<Environments> Get()
        {
            return _environmentManager.GetEnvironments();
        }

        [HttpPost]
        public void Post([FromBody] string env) 
        {
            _environmentManager.CreateContainer();
        }
    }
}