using System;
using System.Runtime.InteropServices;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests.Integration.TestFixtures
{
    public abstract class TestBaseForV3
    {
        private const string ApiKeyVariableName = "tmdbapikey";
        protected readonly ITmdbEasyClient _client;

        protected TestBaseForV3()
        {
            _client = GetTestV3Client();
            _userApiKey = GetApiKey();
        }

        public readonly string _userApiKey;

        public ITmdbEasyClient GetTestV3Client(string sharedApiKey = null)
        {
            var jsonSerializer = new NewtonSoftDeserializer();

            return new TmdbEasyClientv3(jsonSerializer, GetDefaultOptions(sharedApiKey));
        }

        public TmdbEasyOptions GetDefaultOptions(string sharedApiKey)
        {
            return new TmdbEasyOptions(sharedApiKey, useSsl: true, defaultLanguage: "en");
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
