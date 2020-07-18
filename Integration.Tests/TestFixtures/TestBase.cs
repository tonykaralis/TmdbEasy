using System;
using System.Runtime.InteropServices;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Integration.Tests.TestFixtures
{
    public abstract class TestBase
    {
        private const string ApiKeyVariableName = "tmdbapikey";
        private const string ApiBearerTokenVariableName = "tmdbapibearertoken";

        public ITmdbEasyClient GetTestV3Client()
        {
            var jsonSerializer = new NewtonSoftDeserializer();

            return new TmdbEasyClientv3(jsonSerializer, GetDefaultV3Options());
        }

        public ITmdbEasyClient GetTestV4Client()
        {
            var jsonSerializer = new NewtonSoftDeserializer();

            return new TmdbEasyClientv4(jsonSerializer, GetDefaultV4Options());
        }

        public TmdbEasyOptions GetDefaultV3Options()
        {
            return new TmdbEasyOptions()
            {
                UseSsl = true,
                ApiVersion = ApiVersion.v3
            };
        }

        public TmdbEasyOptions GetDefaultV4Options()
        {
            return new TmdbEasyOptions()
            {
                UseSsl = true,
                ApiVersion = ApiVersion.v4
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
