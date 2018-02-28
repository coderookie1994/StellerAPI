using System.Collections.Generic;
using System.Threading.Tasks;
using Docker.DotNet.Models;

namespace StellerAPI.Repository
{
    public interface IContainerRepository
    {
        Task<CreateContainerResponse> CreateContainer();
        // Task<IList<ImagesListResponse>> CreateContainer();
    }
}