using MongoDB.Driver;

using StellerAPI.Models;

namespace StellerAPI.Manager
{
    public interface IEnvironmentManager {
        IMongoCollection<Environments> GetEnvironments();
    }
}