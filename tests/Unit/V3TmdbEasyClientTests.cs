using NUnit.Framework;
using System;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests.Unit
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
        public void NullOptions_Throws_ArgumentNullException()
        {
            TmdbEasyOptions options = null;

            Assert.Throws<ArgumentNullException>(() => new TmdbEasyClientv3(_jsonDeserializer, options));
        }
    }
}
