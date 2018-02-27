using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using StellerAPI.StellerCore;
using StellerAPI.Models;

namespace StellerAPI.Manager
{
    public class EnvironmentManager : IEnvironmentManager
    {
        private readonly IOptions<DbConnectionSettings> _settings;
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database; 
        public EnvironmentManager(IOptions<DbConnectionSettings> settings)
        {
            _settings = settings;
            _client = new MongoClient(settings.Value.ConnectionString);
            if(_client != null)
                _database = _client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Environments> GetEnvironments()
        {
            return _database.GetCollection<Environments>(_settings.Value.Collections.Environments);
        }
    }
}