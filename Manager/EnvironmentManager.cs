using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using StellerAPI.StellerCore;
using StellerAPI.Models;
using StellerAPI.Repository;

namespace StellerAPI.Manager
{
    public class EnvironmentManager : IEnvironmentManager
    {
        private readonly IOptions<DbConnectionSettings> _settings;
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IContainerRepository _repository;
        public EnvironmentManager(IOptions<DbConnectionSettings> settings,
            IContainerRepository repository)
        {
            _settings = settings;
            _client = new MongoClient(settings.Value.ConnectionString);
            _repository = repository;
            if(_client != null)
                _database = _client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Environments> GetEnvironments()
        {
            return _database.GetCollection<Environments>(_settings.Value.Collections.Environments);
        }

        public void CreateContainer()
        {
            _repository.CreateContainer();
        }
    }
}