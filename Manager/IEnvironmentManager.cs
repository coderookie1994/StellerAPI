using System.Threading.Tasks;
using MongoDB.Driver;

using StellerAPI.Models;

namespace StellerAPI.Manager
{
    public interface IEnvironmentManager {
        Task<IMongoCollection<Environments>> GetEnvironments();
        Task<bool> CreateContainer();
    }
}