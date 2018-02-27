using Docker.DotNet;

namespace StellerAPI.StellerCore
{
    public interface IDockerClientWrapper
    {
        DockerClient GetDockerClient(string uri);
    }
}