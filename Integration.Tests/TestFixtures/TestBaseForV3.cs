using System;
using System.Runtime.InteropServices;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Integration.Tests.TestFixtures
{
    public abstract class TestBaseForV3
    {
        public readonly ITmdbEasyClient _client;
        public readonly string _userApiKey;
        private const string ApiKeyVariableName = "tmdbapikey";

        protected TestBaseForV3()
        {
            _client = GetTestV3Client();
            _userApiKey = GetApiKey();
        }

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
    }
}
