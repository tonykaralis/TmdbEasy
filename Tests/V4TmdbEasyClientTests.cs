using NUnit.Framework;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests
{
    [TestFixture]
    public class V4TmdbEasyClientTests
    {
        private readonly IJsonDeserializer _jsonDeserializer;

        public V4TmdbEasyClientTests()
        {
            _jsonDeserializer = new NewtonSoftDeserializer();
        }

        [Test]
        public void OptionsWithSsl_Off_SetsCorrectVersionOfUrl_WithNoSsl()
        {
            var options = new TmdbEasyOptions()
            {
                UseSsl = false
            };

            var client = new TmdbEasyClientv4(_jsonDeserializer, options);

            Assert.AreEqual(Constants.TmdbUrl4, client.GetBaseUrl());
        }

        [Test]
        public void OptionsWithSsl_On_SetsCorrectVersionOfUrl_WithSsl()
        {
            var options = new TmdbEasyOptions()
            {
                UseSsl = true
            };

            var client = new TmdbEasyClientv4(_jsonDeserializer, options);

            Assert.AreEqual(Constants.TmdbUrl4Ssl, client.GetBaseUrl());
        }
    }
}
