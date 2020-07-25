using System;
using System.Runtime.InteropServices;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Integration.Tests.TestFixtures
{
    public abstract class TestBaseForV3
    {
        private const string ApiKeyVariableName = "tmdbapikey";
        private const string ApiBearerTokenVariableName = "tmdbapibearertoken";

        public ITmdbEasyClient GetTestV3Client(string sharedApiKey = null)
        {
            var jsonSerializer = new NewtonSoftDeserializer();

            return new TmdbEasyClientv3(jsonSerializer, GetDefaultOptions(sharedApiKey));
        }

        public TmdbEasyOptions GetDefaultOptions(string sharedApiKey)
        {
            return new TmdbEasyOptions()
            {
                UseSsl = true,
                ApiKey = sharedApiKey
            };
        }

        public string GetApiKey()
        {
            EnvironmentVariableTarget environmentVariableTarget = EnvironmentVariableTarget.User;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                environmentVariableTarget = EnvironmentVariableTarget.Process;
            }

            return Environment.GetEnvironmentVariable(ApiKeyVariableName, environmentVariableTarget);
        }

        public string GetApiBearerToken()
        {
            EnvironmentVariableTarget environmentVariableTarget = EnvironmentVariableTarget.User;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                environmentVariableTarget = EnvironmentVariableTarget.Process;
            }

            return Environment.GetEnvironmentVariable(ApiBearerTokenVariableName, environmentVariableTarget);
        }
    }
}
