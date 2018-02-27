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
        private readonly IOptions<DbConnectionSettings> _settings;
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IEnvironmentManager _environmentManager;
        public EnvironmentsController(IOptions<DbConnectionSettings> settings,
            IEnvironmentManager environmentManager)
        {
            _settings = settings;
            _client = new MongoClient(settings.Value.ConnectionString);
            if(_client != null)
                _database = _client.GetDatabase(settings.Value.Database);
            
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

        }
    }
}