using Docker.DotNet;

namespace StellerAPI.StellerCore
{
    public class DockerClientBuilder : IDockerClientBuilder
    {
        public DockerClient GetDockerClient(string uri = "npipe://./pipe/docker_engine")
        {
            return new DockerClientConfiguration(new System.Uri(uri)).CreateClient();
        }
    }
}