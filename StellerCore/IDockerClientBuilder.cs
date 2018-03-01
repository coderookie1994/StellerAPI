using Docker.DotNet;

namespace StellerAPI.StellerCore
{
    public interface IDockerClientBuilder
    {
        DockerClient GetDockerClient(string uri = "npipe://./pipe/docker_engine");
    }
}