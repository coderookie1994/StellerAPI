using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using StellerAPI.StellerCore;
using StellerAPI.Models;
using StellerAPI.Repository;
using Docker.DotNet.Models;

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

        public async Task<IMongoCollection<Environments>> GetEnvironments()
        {
            return _database.GetCollection<Environments>(_settings.Value.Collections.Environments);
        }

        public async Task<bool> CreateContainer()
        {
            var createContainerResponse = await _repository.CreateContainer();
            return await StartContainer(createContainerResponse);
        }

        private async Task<bool> StartContainer(CreateContainerResponse containerResponse)
        {
            return await _repository.StartContainer(containerResponse.ID);
        }
    }
}