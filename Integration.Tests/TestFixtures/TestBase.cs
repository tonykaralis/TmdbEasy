using System;
using System.Runtime.InteropServices;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Integration.Tests.TestFixtures
{
    public abstract class TestBase
    {
        private const string ApiKeyVariableName = "tmdbapikey";

        public ITmdbEasyClient GetTestClient()
        {
            var options = GetTmdbEasyOptions();

            var jsonSerializer = new NewtonSoftDeserializer();

            return new TmdbEasyClient(jsonSerializer, options);
        }

        private TmdbEasyOptions GetTmdbEasyOptions()
        {
            EnvironmentVariableTarget environmentVariableTarget = EnvironmentVariableTarget.User;            

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                environmentVariableTarget = EnvironmentVariableTarget.Process;                
            }

            string apiKey = Environment.GetEnvironmentVariable(ApiKeyVariableName, environmentVariableTarget);

            return new TmdbEasyOptions()
            {
                ApiKey = apiKey
            };
        }
    }
}
