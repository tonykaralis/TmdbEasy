using System;
using System.Runtime.InteropServices;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests.Integration.TestFixtures
{
    public abstract class TestBaseForV3
    {
        private const string ApiKeyVariableName = "tmdbapikey";
        protected readonly ITmdbEasyClient _clientWithNoApiKey;
        protected readonly ITmdbEasyClient _clientWithApiKey;

        protected TestBaseForV3()
        {
            _clientWithNoApiKey = GetTestV3Client();
            _clientWithApiKey = GetTestV3Client(GetApiKey());
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
