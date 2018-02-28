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
        public ContainerRepository(IDockerClientWrapper dockerClientWrapper)
        {
            _client = dockerClientWrapper.GetDockerClient();
        }
        public async Task<CreateContainerResponse> CreateContainer()
        {
            var createContainerResponse =_client.Containers.CreateContainerAsync(
                new CreateContainerParameters
                {
                    Image = Environments.Python
                }
            );
            return createContainerResponse.Result;
        }

        // public async Task<IList<ImagesListResponse>> CreateContainer()
        // {
        //     var list = _client.Images.ListImagesAsync(new ImagesListParameters{All = true});
        //     var list2 = list.Result;

        //     foreach(var l in list2)
        //     {
        //         Debug.WriteLine(l.ID);
        //     }
        //     return list.Result;
        // }
    }
}