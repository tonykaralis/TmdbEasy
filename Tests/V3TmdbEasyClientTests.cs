using NUnit.Framework;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests
{
    [TestFixture]
    public class V3TmdbEasyClientTests
    {
        private readonly IJsonDeserializer _jsonDeserializer;

        public V3TmdbEasyClientTests()
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

            var client = new TmdbEasyClientv3(_jsonDeserializer, options);

            Assert.AreEqual(Constants.TmdbUrl3, client.GetBaseUrl());
        }

        [Test]
        public void OptionsWithSsl_On_SetsCorrectVersionOfUrl_WithSsl()
        {
            var options = new TmdbEasyOptions()
            {
                UseSsl = true
            };

            var client = new TmdbEasyClientv3(_jsonDeserializer, options);

            Assert.AreEqual(Constants.TmdbUrl3Ssl, client.GetBaseUrl());
        }
    }
}
