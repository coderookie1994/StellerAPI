using System.Threading.Tasks;
using System.Collections.Generic;
using Docker.DotNet;
using Docker.DotNet.Models;

using StellerAPI.StellerCommon;
using StellerAPI.StellerCore;
using System.Collections;
using System.Diagnostics;

namespace StellerAPI.Repository
{
    public class ContainerRepository : IContainerRepository
    {
        private readonly DockerClient _client; 
        public ContainerRepository(IDockerClientBuilder dockerClientBuilder)
        {
            _client = dockerClientBuilder.GetDockerClient();
        }
        public async Task<CreateContainerResponse> CreateContainer()
        {
            var createContainerResponse = await _client.Containers.CreateContainerAsync(
                new CreateContainerParameters
                {
                    Image = Environments.Python
                }
            );
            return createContainerResponse;
        }

        public async Task<bool> StartContainer(string containerId)
        {
            var startContainerResponse = await _client.Containers.StartContainerAsync(
                containerId, new ContainerStartParameters{});
            return startContainerResponse;
        }
    }
}